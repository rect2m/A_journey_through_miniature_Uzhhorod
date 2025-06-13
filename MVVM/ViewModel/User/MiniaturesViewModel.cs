using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.Database.Models.Translation;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Service;
using A_journey_through_miniature_Uzhhorod.Properties;
using A_journey_through_miniature_Uzhhorod.Resources;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    public class MiniaturesViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;
        private readonly MiniatureDetailsViewModel _detailsViewModel;
        private readonly QuestService _questService;
        private string _currentLanguage => Settings.Default.LanguageCode;
        private const int PageSize = 15;

        public ObservableCollection<MiniatureViewModel> PagedMiniatures { get; set; } = new();
        private List<MiniatureViewModel> _allMiniatures = new();
        private List<MiniatureViewModel> _filteredMiniatures = new();

        private string _searchQuery = string.Empty;
        public string SearchQuery
        {
            get => _searchQuery;
            set { _searchQuery = value; OnPropertyChanged(nameof(SearchQuery)); ApplyFilterAndPagination(); }
        }

        private bool _isSortingAscending = true;
        public bool IsSortingAscending
        {
            get => _isSortingAscending;
            set { _isSortingAscending = value; OnPropertyChanged(nameof(IsSortingAscending)); OnPropertyChanged(nameof(SortIcon)); ApplyFilterAndPagination(); }
        }

        public string SortIcon => _currentLanguage == "uk" ? (_isSortingAscending ? "▲ А-Я" : "▼ Я-А") : (_isSortingAscending ? "▲ A-Z" : "▼ Z-A");

        private int _currentPage = 1;
        public int CurrentPage
        {
            get => _currentPage;
            set { _currentPage = value; OnPropertyChanged(nameof(CurrentPage)); LoadPagedMiniatures(); }
        }

        private int _totalMiniaturesCount;
        public int TotalMiniaturesCount
        {
            get => _totalMiniaturesCount;
            set { _totalMiniaturesCount = value; OnPropertyChanged(nameof(TotalMiniaturesCount)); }
        }

        public int TotalPages => (int)Math.Ceiling((double)_filteredMiniatures.Count / PageSize);

        private bool _showOnlyFavorites;
        public bool ShowOnlyFavorites
        {
            get => _showOnlyFavorites;
            set { _showOnlyFavorites = value; OnPropertyChanged(nameof(ShowOnlyFavorites)); ApplyFilterAndPagination(); }
        }

        public ICommand ChangeLanguageCommand { get; }
        public ICommand SelectMiniatureCommand { get; }
        public ICommand ToggleSortingCommand { get; }
        public ICommand ToggleFavoritesFilterCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand PrevPageCommand { get; }

        public event Action<ViewModelBase> OnNavigate;

        public MiniaturesViewModel(IAppDbContextFactory contextFactory, MiniatureDetailsViewModel detailsViewModel, QuestService questService)
        {
            _contextFactory = contextFactory;
            _detailsViewModel = detailsViewModel;
            _questService = questService;

            ChangeLanguageCommand = new ViewModelCommand(ChangeLanguage);
            SelectMiniatureCommand = new ViewModelCommand(ExecuteSelectMiniatureCommand);
            ToggleSortingCommand = new ViewModelCommand(_ => IsSortingAscending = !IsSortingAscending);
            ToggleFavoritesFilterCommand = new ViewModelCommand(ExecuteToggleFavoritesFilter);
            NextPageCommand = new ViewModelCommand(_ => { if (CurrentPage < TotalPages) CurrentPage++; });
            PrevPageCommand = new ViewModelCommand(_ => { if (CurrentPage > 1) CurrentPage--; });

            _detailsViewModel.OnNavigateBack += _ => OnNavigate?.Invoke(this);

            LanguageManager.LanguageChanged += () =>
            {
                LoadMiniatures();
                if (_detailsViewModel.SelectedMiniature != null)
                    _detailsViewModel.ReloadMiniatureDetails();
                OnPropertyChanged(nameof(SortIcon));
            };

            LoadMiniatures();
        }

        private void ExecuteToggleFavoritesFilter(object obj)
        {
            if (string.IsNullOrWhiteSpace(Settings.Default.username))
            {
                ShowErrorMessageBox(Strings.RegOrLogProfile);
                return;
            }
            ShowOnlyFavorites = !ShowOnlyFavorites;
        }

        private void ShowErrorMessageBox(string text)
        {
            var box = new View.MessageBoxView
            {
                TextBlockProblem1 = { Text = text },
                ButtonYes = { Visibility = Visibility.Hidden },
                ButtonNo = { Visibility = Visibility.Hidden },
                IconSuccess = { Visibility = Visibility.Hidden },
                IconThink = { Visibility = Visibility.Hidden }
            };
            box.ShowDialog();
        }

        private void LoadMiniatures()
        {
            using var context = _contextFactory.CreateContext();

            PagedMiniatures.Clear();
            _allMiniatures.Clear();

            var miniatures = context.Miniatures.Include(m => m.Translations).AsNoTracking().ToList();

            foreach (var miniature in miniatures)
            {
                var translation = miniature.Translations.FirstOrDefault(t => t.LanguageCode == _currentLanguage);
                if (translation == null) continue;

                _allMiniatures.Add(new MiniatureViewModel
                {
                    Id = miniature.Id,
                    Name = translation.Name,
                    Description = translation.Description,
                    Latitude = miniature.Latitude,
                    Longitude = miniature.Longitude,
                    ImageUrl = miniature.ImageUrl,
                    ModelUrl = miniature.ModelUrl
                });
            }

            TotalMiniaturesCount = _allMiniatures.Count;
            ApplyFilterAndPagination();
        }

        private void ApplyFilterAndPagination()
        {
            using var context = _contextFactory.CreateContext();

            var filtered = _allMiniatures.AsEnumerable();

            if (ShowOnlyFavorites)
            {
                var user = context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
                if (user != null)
                {
                    var favoriteIds = context.FavoriteMiniatures
                        .Where(f => f.UserId == user.Id)
                        .Select(f => f.MiniatureId)
                        .ToHashSet();
                    filtered = filtered.Where(m => favoriteIds.Contains(m.Id));
                }
            }

            if (!string.IsNullOrWhiteSpace(SearchQuery))
                filtered = filtered.Where(m => m.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));

            filtered = IsSortingAscending ? filtered.OrderBy(m => m.Name) : filtered.OrderByDescending(m => m.Name);

            _filteredMiniatures = filtered.ToList();
            CurrentPage = 1;
            LoadPagedMiniatures();
            OnPropertyChanged(nameof(TotalPages));
        }

        private void LoadPagedMiniatures()
        {
            PagedMiniatures.Clear();
            foreach (var item in _filteredMiniatures.Skip((CurrentPage - 1) * PageSize).Take(PageSize))
            {
                item.LoadImageAsync();
                PagedMiniatures.Add(item);
            }
        }

        private void ChangeLanguage(object obj)
        {
            Settings.Default.LanguageCode = _currentLanguage == "uk" ? "en" : "uk";
            Settings.Default.Save();
            LanguageManager.NotifyLanguageChanged();
        }

        private void ExecuteSelectMiniatureCommand(object obj)
        {
            if (obj is MiniatureViewModel selectedMiniature)
            {
                using var context = _contextFactory.CreateContext();
                _detailsViewModel.LoadMiniature(selectedMiniature);

                var miniature = context.Miniatures.Include(m => m.Translations).FirstOrDefault(m => m.Id == selectedMiniature.Id);
                string nameUk = selectedMiniature.Name;
                string nameEn = miniature?.Translations.FirstOrDefault(t => t.LanguageCode == "en")?.Name ?? nameUk;

                LogUserActivity("Перегляд скульптурки", "Miniature viewed", nameUk, nameEn);

                var user = context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
                if (user != null)
                {
                    _questService.UpdateMiniatureViewQuest(user.Id, selectedMiniature.Id);
                }

                OnNavigate?.Invoke(_detailsViewModel);
            }
        }

        private void LogUserActivity(string actionUk, string actionEn, string detailsUk = "", string detailsEn = "")
        {
            using var context = _contextFactory.CreateContext();
            var user = context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
            if (user == null) return;

            var activity = new UserActivity { UserId = user.Id, Timestamp = DateTime.UtcNow.AddHours(3) };
            context.UserActivities.Add(activity);
            context.SaveChanges();

            context.UserActivityTranslations.AddRange(new[]
            {
                new UserActivityTranslation { UserActivityId = activity.Id, LanguageCode = "uk", Action = actionUk, Details = detailsUk },
                new UserActivityTranslation { UserActivityId = activity.Id, LanguageCode = "en", Action = actionEn, Details = detailsEn }
            });
            context.SaveChanges();
        }

        public class MiniatureViewModel : ViewModelBase
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string ImageUrl { get; set; }
            public string ImagePath { get; set; }
            public string ModelUrl { get; set; }

            private BitmapImage _image;
            public BitmapImage ImageSource
            {
                get => _image ?? new BitmapImage(new Uri("https://minisculptures.blob.core.windows.net/images/notFound.png"));
                private set
                {
                    _image = value;
                    OnPropertyChanged(nameof(ImageSource));
                }
            }

            private bool _isFavorite;
            public bool IsFavorite
            {
                get => _isFavorite;
                set { _isFavorite = value; OnPropertyChanged(nameof(IsFavorite)); }
            }

            private double _averageRating;
            public double AverageRating
            {
                get => _averageRating;
                set { _averageRating = value; OnPropertyChanged(nameof(AverageRating)); }
            }

            public async Task LoadImageAsync()
            {
                try
                {
                    string cacheDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MiniatureCache");
                    Directory.CreateDirectory(cacheDir);

                    string fileName = Path.GetFileName(ImageUrl);
                    string localPath = Path.Combine(cacheDir, fileName);

                    if (!File.Exists(localPath) || new FileInfo(localPath).Length == 0)
                    {
                        using var client = new WebClient();
                        await client.DownloadFileTaskAsync(new Uri(ImageUrl), localPath);
                    }

                    if (!File.Exists(localPath) || new FileInfo(localPath).Length == 0)
                    {
                        await SetPlaceholderImageAsync();
                        return;
                    }

                    byte[] imageBytes = await File.ReadAllBytesAsync(localPath);

                    await Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        try
                        {
                            using var ms = new MemoryStream(imageBytes);
                            var bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.StreamSource = ms;
                            bitmap.EndInit();
                            bitmap.Freeze();
                            ImageSource = bitmap;
                        }
                        catch
                        {
                            _ = SetPlaceholderImageAsync();
                        }
                    });
                }
                catch
                {
                    await SetPlaceholderImageAsync();
                }
            }

            private async Task SetPlaceholderImageAsync()
            {
                try
                {
                    string placeholderUrl = "https://minisculptures.blob.core.windows.net/images/notFound.png";
                    string fileName = Path.GetFileName(placeholderUrl);
                    string cacheDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MiniatureCache");
                    string localPath = Path.Combine(cacheDir, fileName);

                    if (!File.Exists(localPath))
                    {
                        using var client = new WebClient();
                        await client.DownloadFileTaskAsync(new Uri(placeholderUrl), localPath);
                    }

                    await Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.UriSource = new Uri(localPath);
                        bitmap.EndInit();
                        bitmap.Freeze();
                        ImageSource = bitmap;
                    });
                }
                catch
                {
                }
            }
        }
    }
}
