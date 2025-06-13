using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.MVVM.Model;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Notification;
using A_journey_through_miniature_Uzhhorod.MVVM.ViewModel;
using A_journey_through_miniature_Uzhhorod.Properties;
using A_journey_through_miniature_Uzhhorod.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace A_journey_through_miniature_Uzhhorod.MVVM.View
{
    public partial class MainWindowView : Window
    {
        public static MainWindowView Instance { get; private set; }
        private readonly AppDbContext _context;
        private bool _isMenuOpen = true;

        public MainWindowView(MainViewModel mainViewModel, AppDbContext context)
        {
            InitializeComponent();

            var toastManager = App._host.Services.GetRequiredService<ToastManager>();
            toastManager.SetContainer(ToastContainer);

            DataContext = mainViewModel;
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Instance = this;
            LoadUserData();

            LanguageManager.LanguageChanged += () =>
            {
                if (string.IsNullOrWhiteSpace(Settings.Default.username))
                {
                    SetGuestMode();
                }
            };
        }

        public void RadioButtonHome_Check()
        {
            RadioButtonHome.IsChecked = true;
        }

        public void LoadUserData()
        {
            string activeUser = Settings.Default.username;

            if (!string.IsNullOrWhiteSpace(activeUser))
            {
                var user = _context.Users
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Username == activeUser);

                if (user != null)
                {
                    TextBlockUserName.Text = activeUser;

                    string avatarUrl = string.IsNullOrWhiteSpace(user.AvatarUrl)
                        ? "https://minisculptures.blob.core.windows.net/avatars/avatar.png"
                        : $"https://minisculptures.blob.core.windows.net/avatars/{user.AvatarUrl}";

                    ImageBrush avatarBrush = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri(avatarUrl, UriKind.Absolute)),
                        Stretch = Stretch.UniformToFill
                    };
                    AvatarImage.Fill = avatarBrush;

                    AvatarImage.Visibility = Visibility.Visible;

                    if (user.Role == UserRole.Admin)
                    {
                        AdminPanel.Visibility = Visibility.Visible;
                        UserPanel.Visibility = Visibility.Collapsed;
                        TextBlockUserName.Foreground = Brushes.Red;
                    }
                    else
                    {
                        AdminPanel.Visibility = Visibility.Collapsed;
                        UserPanel.Visibility = Visibility.Visible;
                        TextBlockUserName.Foreground = (Brush)FindResource("titleColor3");
                    }
                }
                else
                {
                    SetGuestMode();
                }
            }
            else
            {
                SetGuestMode();
            }
        }

        public void SetDefaultAvatar()
        {
            AvatarImage.Fill = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("https://minisculptures.blob.core.windows.net/avatars/avatar.png", UriKind.Absolute)),
                Stretch = Stretch.UniformToFill
            };
        }

        public void SetGuestMode()
        {
            TextBlockUserName.Text = Strings.MainTextBlockUserName;
            TextBlockUserName.Margin = new Thickness(5, 0, -50, 0);
            AvatarImage.Visibility = Visibility.Hidden;
            AdminPanel.Visibility = Visibility.Collapsed;
            UserPanel.Visibility = Visibility.Visible;
            TextBlockUserName.Foreground = (Brush)FindResource("titleColor3");
        }

        private void PnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            string activeUser = Settings.Default.username;
            if (!string.IsNullOrEmpty(activeUser))
            {
                MessageBoxView messageBoxView = new MessageBoxView();
                messageBoxView.TextBlockProblem1.Text = Strings.LogOut;
                messageBoxView.ButtonOk.Content = Strings.Cancel;
                messageBoxView.ButtonYes.Visibility = Visibility.Visible;
                messageBoxView.ButtonNo.Visibility = Visibility.Visible;
                messageBoxView.ButtonOk.Visibility = Visibility.Visible;
                messageBoxView.ButtonYes.Margin = new Thickness(-40, 0, 10, 10);
                messageBoxView.ButtonNo.Margin = new Thickness(-40, 0, 87, 10);
                messageBoxView.IconSuccess.Visibility = Visibility.Hidden;
                messageBoxView.IconThink.Visibility = Visibility.Visible;
                messageBoxView.IconError.Visibility = Visibility.Hidden;
                messageBoxView.ShowDialog();

                if (MessageBoxView.buttonYesClicked == true)
                {
                    SaveUserInSettings(string.Empty);
                    Application.Current.Shutdown();
                    MessageBoxView.buttonYesClicked = false;
                }
                else if (MessageBoxView.buttonNoClicked == true)
                {
                    Application.Current.Shutdown();
                    MessageBoxView.buttonNoClicked = false;
                }
                else
                {
                    messageBoxView.Close();
                    MessageBoxView.buttonOkClicked = false;
                }
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        public static void SaveUserInSettings(string username)
        {
            Settings.Default.username = username;
            Settings.Default.Save();
        }

        private void ButtonMaximazed_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;
        }

        private void ButtonMinimaze_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (TextBlockUserName.Text == "Натисніть щоб увійти" || TextBlockUserName.Text == "Click to enter")
            {
                var authWindow = App._host.Services.GetRequiredService<AuthWindowView>();
                authWindow.Show();

                Window main = Window.GetWindow(this);
                main.Close();
            }
        }

        private void ToggleMenu_Click(object sender, RoutedEventArgs e)
        {
            double newMenuWidth = _isMenuOpen ? 79 : 250;
            var easingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut };

            GridLengthAnimation animation = new GridLengthAnimation
            {
                From = MenuColumn.Width,
                To = new GridLength(newMenuWidth),
                Duration = TimeSpan.FromSeconds(0.3)
            };

            MenuColumn.BeginAnimation(ColumnDefinition.WidthProperty, animation);

            MenuIcon.Icon = _isMenuOpen ? FontAwesome.Sharp.IconChar.ArrowRight : FontAwesome.Sharp.IconChar.Bars;

            ThicknessAnimation iconAnimation = new ThicknessAnimation
            {
                To = _isMenuOpen ? new Thickness(25, 15, 15, 15) : new Thickness(15),
                Duration = TimeSpan.FromSeconds(0.3)
            };
            ToggleButton.BeginAnimation(MarginProperty, iconAnimation);

            LogoPanel.Visibility = _isMenuOpen ? Visibility.Collapsed : Visibility.Visible;

            void ToggleStackPanelMenu(StackPanel panel)
            {
                foreach (var child in panel.Children)
                {
                    if (child is RadioButton rb && rb.Content is StackPanel sp && sp.Children.Count > 1)
                    {
                        sp.Children[1].Visibility = _isMenuOpen ? Visibility.Collapsed : Visibility.Visible;
                    }
                }
            }

            ToggleStackPanelMenu(UserPanel);

            if (AdminPanel != null)
            {
                ToggleStackPanelMenu(AdminPanel);
            }

            _isMenuOpen = !_isMenuOpen;
        }

        private void RadioButtonPersonalOffice_Checked(object sender, RoutedEventArgs e)
        {
            string activeUser = Settings.Default.username;
            if (string.IsNullOrWhiteSpace(activeUser))
            {
                ShowErrorMessageBox("Для перегляду особистого кабінету спочатку увійдіть в аккаунт.");
                var authWindow = App._host.Services.GetRequiredService<AuthWindowView>();
                authWindow.Show();

                Window main = Window.GetWindow(this);
                main.Close();
            }
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

        private void Change_Language_Click(object sender, RoutedEventArgs e)
        {
            LoadUserData();
        }
    }
}
