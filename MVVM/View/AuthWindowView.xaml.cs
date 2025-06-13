using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.MVVM.Model;
using A_journey_through_miniature_Uzhhorod.MVVM.ViewModel;
using A_journey_through_miniature_Uzhhorod.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using Application = System.Windows.Application;

namespace A_journey_through_miniature_Uzhhorod.MVVM.View
{
    /// <summary>
    /// Interaction logic for AuthWindowView.xaml
    /// </summary>
    public partial class AuthWindowView : Window
    {
        private readonly string _iconDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons");

        public AuthWindowView()
        {
            InitializeComponent();

            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", "monkey_watch.png");
            AuthLogoImage.Source = new BitmapImage(new Uri(imagePath));
        }

        //Передвигання вікна
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        //кнопка звернути вікно
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //Кнопка закрити вікно
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Відкривання головного меню для повернення
        private void TextBlockBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var authWindow = App._host.Services.GetRequiredService<MainWindowView>();
            authWindow.Show();

            Window welcome = Window.GetWindow(this);
            welcome.Close();
        }

        private void TextBlockRegistration_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HideStackPanel(LoginStackPanel, () => ShowStackPanel(RegStackPanel));

        }

        private void TextBlockLogin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HideStackPanel(RegStackPanel, () => ShowStackPanel(LoginStackPanel));
        }

        private void HideStackPanel(StackPanel panel, System.Action onComplete)
        {
            Storyboard sb = (Storyboard)FindResource("HidePanel");
            sb.Completed += (s, e) =>
            {
                panel.Visibility = Visibility.Collapsed;
                onComplete?.Invoke();
            };
            sb.Begin(panel);
        }

        private void ShowStackPanel(StackPanel panel)
        {
            panel.Visibility = Visibility.Visible;
            panel.Opacity = 0;
            Storyboard sb = (Storyboard)FindResource("ShowPanel");
            sb.Begin(panel);
        }

        //Кнопка увійти
        public async void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginTextBoxUser.BorderBrush = System.Windows.Media.Brushes.Gray;
            LoginPasswordBoxPass.BorderBrush = System.Windows.Media.Brushes.Gray;

            string username = LoginTextBoxUser.Text;
            string password = LoginPasswordBoxPass.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                if (string.IsNullOrWhiteSpace(username)) LoginTextBoxUser.BorderBrush = System.Windows.Media.Brushes.Red;
                if (string.IsNullOrWhiteSpace(password)) LoginPasswordBoxPass.BorderBrush = System.Windows.Media.Brushes.Red;
                ShowErrorMessageBox(Strings.FillAllFieldsMessage);
                return;
            }

            if (!Validator.IsValidUsername(username))
            {
                LoginTextBoxUser.BorderBrush = System.Windows.Media.Brushes.Red;
                ShowErrorMessageBox(Strings.UsernameValidation);
                return;
            }

            if (!Validator.IsValidPassword(password))
            {
                LoginPasswordBoxPass.BorderBrush = System.Windows.Media.Brushes.Red;
                ShowErrorMessageBox(Strings.PasswordValidation);
                return;
            }

            using (var scope = App._host.Services.CreateScope())
            {
                var authService = scope.ServiceProvider.GetRequiredService<AuthViewModel>();
                var user = await authService.LoginUser(username, password);

                if (user != null)
                {
                    if (user.Status == UserStatus.Blocked)
                    {
                        ShowErrorMessageBox(Strings.AccountBlocked);
                        return;
                    }

                    ShowSuccessMessageBox(Strings.AuthSuccessful);
                    var mainWindow = App._host.Services.GetRequiredService<MainWindowView>();
                    mainWindow.Show();

                    Window welcome = Window.GetWindow(this);
                    welcome.Close();
                }
                else
                {
                    ShowErrorMessageBox(Strings.UnfaithfulUsernameOrPassword);
                }
            }
        }


        public async void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            RegTextBoxUser.BorderBrush = System.Windows.Media.Brushes.Gray;
            RegTextBoxMail.BorderBrush = System.Windows.Media.Brushes.Gray;
            RegPasswordBoxPass.BorderBrush = System.Windows.Media.Brushes.Gray;

            string username = RegTextBoxUser.Text;
            string email = RegTextBoxMail.Text;
            string password = RegPasswordBoxPass.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                if (string.IsNullOrWhiteSpace(username)) RegTextBoxUser.BorderBrush = System.Windows.Media.Brushes.Red;
                if (string.IsNullOrWhiteSpace(email)) RegTextBoxMail.BorderBrush = System.Windows.Media.Brushes.Red;
                if (string.IsNullOrWhiteSpace(password)) RegPasswordBoxPass.BorderBrush = System.Windows.Media.Brushes.Red;
                ShowErrorMessageBox(Strings.FillAllFields);
                return;
            }

            if (!Validator.IsValidUsername(username))
            {
                RegTextBoxUser.BorderBrush = System.Windows.Media.Brushes.Red;
                ShowErrorMessageBox(Strings.UsernameValidation);
                return;
            }

            if (!Validator.IsValidEmail(email))
            {
                RegTextBoxMail.BorderBrush = System.Windows.Media.Brushes.Red;
                ShowErrorMessageBox(Strings.IncorrectEmailFormat);
                return;
            }

            if (!Validator.IsValidPassword(password))
            {
                RegPasswordBoxPass.BorderBrush = System.Windows.Media.Brushes.Red;
                ShowErrorMessageBox(Strings.PasswordValidation);
                return;
            }

            using (var scope = App._host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<Database.AppDbContext>();

                // 🔒 Перевірка, чи така пошта вже існує
                bool emailExists = await dbContext.Users.AnyAsync(u => u.Email == email);
                if (emailExists)
                {
                    RegTextBoxMail.BorderBrush = System.Windows.Media.Brushes.Red;
                    ShowErrorMessageBox(Strings.EmailAlredyExist); // або заміни текст на "Ця пошта вже зареєстрована."
                    return;
                }

                var authService = scope.ServiceProvider.GetRequiredService<AuthViewModel>();
                bool isRegistered = await authService.RegisterUser(username, email, password);

                if (isRegistered)
                {
                    ShowSuccessMessageBox(Strings.RegSuccsesfully);

                    var mainWindow = App._host.Services.GetRequiredService<MainWindowView>();
                    mainWindow.Show();

                    Window welcome = Window.GetWindow(this);
                    welcome.Close();
                }
                else
                {
                    ShowErrorMessageBox("Не вдалося зареєструвати користувача.");
                }
            }
        }

        private void PasswordBoxPass_GotFocus(object sender, RoutedEventArgs e)
        {
            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", "monkey_close_eyes.png");
            AuthLogoImage.Source = new BitmapImage(new Uri(imagePath));

        }

        private void PasswordBoxPass_LostFocus(object sender, RoutedEventArgs e)
        {
            string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Icons", "monkey_watch.png");
            AuthLogoImage.Source = new BitmapImage(new Uri(imagePath));
        }


        // Допоміжний метод для MessageBox
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