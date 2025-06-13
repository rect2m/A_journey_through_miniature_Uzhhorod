using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Service;
using A_journey_through_miniature_Uzhhorod.Properties;
using A_journey_through_miniature_Uzhhorod.Resources;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace A_journey_through_miniature_Uzhhorod.MVVM.View
{
    public partial class MapPageControlView : UserControl
    {
        private List<string> allMarkers = new List<string>();
        private readonly AppDbContext _context;
        private readonly QuestService _questService;

        public MapPageControlView()
        {
            InitializeComponent();
            _context = App._host.Services.GetService(typeof(AppDbContext)) as AppDbContext;
            _questService = App._host.Services.GetService(typeof(QuestService)) as QuestService;

            LoadMap();

            WebMap.WebMessageReceived += (sender, args) =>
            {
                string message = args.WebMessageAsJson.Trim('"');

                if (message == "clear-search")
                {
                    Dispatcher.Invoke(() => TextBoxSearch.Text = "");
                }
                else if (message == "easter-egg-activated")
                {
                    Dispatcher.Invoke(() =>
                    {
                        ShowSuccessMessageBox(Strings.EasterEgg);

                        var user = _context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
                        if (user != null)
                        {
                            _questService?.MarkSecretQuestCompleted(user.Id);
                        }
                    });
                }
            };

            // Реагуємо на зміну мови
            LanguageManager.LanguageChanged += async () =>
            {
                await SendBaseMapLabelsToWeb();
                ReloadMarkers();
            };
        }

        private async void ButtonClearRoute_Click(object sender, RoutedEventArgs e)
        {
            if (WebMap.CoreWebView2 != null)
                await WebMap.CoreWebView2.ExecuteScriptAsync("clearRoute();");
            ComboBoxFrom.SelectedItem = null;
            ComboBoxTo.SelectedItem = null;
        }


        private async void LoadMap()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.Combine(baseDir, @"MVVM\Model\Map\Map.html");

            if (File.Exists(relativePath))
            {
                WebMap.Source = new Uri(relativePath);
                WebMap.NavigationCompleted += WebMap_NavigationCompleted;
            }
            else
            {
                ShowErrorMessageBox("Файл Map.html не знайдено!");
            }
        }

        private async void WebMap_NavigationCompleted(object sender, EventArgs e)
        {
            await SendBaseMapLabelsToWeb();
            ReloadMarkers();
        }

        private async Task SendBaseMapLabelsToWeb()
        {
            if (WebMap.CoreWebView2 == null)
                return;

            var lang = LanguageManager.CurrentLanguage;

            var labels = new
            {
                OSM = lang == "en" ? "🗺️ General map (OSM)" : "🗺️ Загальна карта (OSM)",
                GoogleSat = lang == "en" ? "🛰️ Satellite map (Google)" : "🛰️ Супутникова карта (Google)",
                GoogleHybrid = lang == "en" ? "🛰️📍 Satellite + Streets" : "🛰️📍 Супутникова карта + Вулиці"
            };

            var json = JsonSerializer.Serialize(labels);
            await WebMap.CoreWebView2.ExecuteScriptAsync($"updateBaseMapLabels({json});");
        }

        private async void ReloadMarkers()
        {
            try
            {
                if (WebMap?.CoreWebView2 == null) return;

                var currentLanguage = Settings.Default.LanguageCode ?? "uk";

                var miniatures = _context.Miniatures
                    .Include(m => m.Translations)
                    .AsNoTracking()
                    .ToList()
                    .Select(m => new
                    {
                        latitude = m.Latitude.ToString(CultureInfo.InvariantCulture),
                        longitude = m.Longitude.ToString(CultureInfo.InvariantCulture),
                        name = m.Translations.FirstOrDefault(t => t.LanguageCode == currentLanguage)?.Name ?? "Unknown",
                        imageUrl = GetBlobImageUrl(m.ImageUrl)
                    })
                    .ToList();

                var json = JsonSerializer.Serialize(miniatures);

                ComboBoxFrom.ItemsSource = miniatures.Select(m => m.name).ToList();
                ComboBoxTo.ItemsSource = miniatures.Select(m => m.name).ToList();

                await WebMap.CoreWebView2.ExecuteScriptAsync($"replaceMarkers({json});");
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(Strings.UpdateMarkers + ex.Message);
            }
        }

        private string GetBlobImageUrl(string? imageUrl)
        {
            const string fallbackImage = "notFound.png";
            const string blobBaseUrl = "https://minisculptures.blob.core.windows.net/images/";

            if (string.IsNullOrWhiteSpace(imageUrl))
                return blobBaseUrl + fallbackImage;

            if (Uri.TryCreate(imageUrl, UriKind.Absolute, out var uri) && uri.Scheme.StartsWith("http"))
                return imageUrl;

            string fileName = Path.GetFileName(imageUrl.Replace("\\", "/"));
            return blobBaseUrl + fileName;
        }


        private async Task LoadMarkers()
        {
            if (WebMap.CoreWebView2 == null) return;

            try
            {
                string script = "JSON.stringify(Object.keys(markers));";
                var result = await WebMap.CoreWebView2.ExecuteScriptAsync(script);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    result = result.Trim('"').Replace("\\", "");
                    allMarkers = JsonSerializer.Deserialize<List<string>>(result);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(Strings.MarkerError + ex.Message);
            }
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string query = TextBoxSearch.Text.ToLower().Trim();

            if (WebMap.CoreWebView2 != null)
            {
                if (string.IsNullOrWhiteSpace(query))
                {
                    WebMap.CoreWebView2.ExecuteScriptAsync("document.getElementById('search-results').style.display = 'none';");
                }
                else if (query == "blueberry")
                {
                    WebMap.CoreWebView2.ExecuteScriptAsync("activateEasterEgg();");
                    Dispatcher.Invoke(() => TextBoxSearch.Text = "");
                }
                else
                {
                    WebMap.CoreWebView2.ExecuteScriptAsync($"updateSearchResults(Object.keys(markers).filter(name => name.includes('{query}')));");
                }
            }
        }

        private async void ButtonBuildRoute_Click(object sender, RoutedEventArgs e)
        {
            var from = ComboBoxFrom.SelectedItem as string;
            var to = ComboBoxTo.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
            {
                ShowErrorMessageBox(Strings.SelectBothSculptures);
                return;
            }

            await BuildRouteBetweenAsync(from, to);
        }

        private async Task BuildRouteBetweenAsync(string fromName, string toName)
        {
            if (WebMap.CoreWebView2 == null)
                return;

            string Escape(string s) => s.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\n", "").Replace("\r", "");
            string js = $"buildRouteBetween(\"{Escape(fromName)}\", \"{Escape(toName)}\");";
            await WebMap.CoreWebView2.ExecuteScriptAsync(js);
        }

        private void ShowErrorMessageBox(string text)
        {
            MessageBoxView messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = text;
            messageBoxView.ButtonYes.Visibility = Visibility.Hidden;
            messageBoxView.ButtonNo.Visibility = Visibility.Hidden;
            messageBoxView.IconSuccess.Visibility = Visibility.Hidden;
            messageBoxView.IconThink.Visibility = Visibility.Hidden;
            messageBoxView.ShowDialog();
        }

        private void ShowSuccessMessageBox(string text)
        {
            MessageBoxView messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = text;
            messageBoxView.ButtonYes.Visibility = Visibility.Hidden;
            messageBoxView.ButtonNo.Visibility = Visibility.Hidden;
            messageBoxView.IconError.Visibility = Visibility.Hidden;
            messageBoxView.IconThink.Visibility = Visibility.Hidden;
            messageBoxView.ShowDialog();
        }
    }
}