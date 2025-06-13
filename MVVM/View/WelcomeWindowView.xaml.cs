using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.Properties;
using A_journey_through_miniature_Uzhhorod.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Windows;
using System.Windows.Input;

namespace A_journey_through_miniature_Uzhhorod.MVVM.View
{
    /// <summary>
    /// Interaction logic for WelcomeWindowView.xaml
    /// </summary>
    public partial class WelcomeWindowView : Window
    {
        public WelcomeWindowView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        //Кнопка звернути вікно
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //Кнопка закрити вікно
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Кнопка перейти до програми
        private async void ButtonToProgram_Click(object sender, RoutedEventArgs e)
        {
            if (!await IsInternetAvailable())
            {
                ShowErrorMessageBox("Немає підключення до Інтернету. Будь ласка, перевірте з'єднання.");
                return;
            }

            string activeUser = Settings.Default.username;

            if (!string.IsNullOrWhiteSpace(activeUser))
            {
                using var context = App._host.Services.GetRequiredService<AppDbContext>();

                var user = context.Users
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Username == activeUser);

                if (user != null)
                {
                    if (user.Status == UserStatus.Blocked)
                    {
                        ShowErrorMessageBox(Strings.AccountBlocked);

                        var authWindow = App._host.Services.GetRequiredService<AuthWindowView>();
                        authWindow.Show();

                        Close();
                        return;
                    }
                    OpenMainWindow();
                    return;
                }
            }

            OpenMainWindow();
        }

        private void OpenMainWindow()
        {
            var mainWindow = App._host.Services.GetRequiredService<MainWindowView>();
            mainWindow.Show();
            Close();
        }


        private async Task<bool> IsInternetAvailable()
        {
            try
            {
                using var client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(3);
                using var response = await client.GetAsync("https://www.google.com");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        //Кнопка вийти з програми
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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
    }
}
