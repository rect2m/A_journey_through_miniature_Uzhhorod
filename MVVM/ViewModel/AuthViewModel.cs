using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.MVVM.Model;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Service;
using A_journey_through_miniature_Uzhhorod.MVVM.View;
using A_journey_through_miniature_Uzhhorod.Properties;
using A_journey_through_miniature_Uzhhorod.Resources;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    class AuthViewModel : AuthWindowView
    {
        private readonly AppDbContext _context;
        private readonly QuestService _questService;
        private readonly MainViewModel _mainViewModel;

        public AuthViewModel(AppDbContext context, QuestService questService, MainViewModel mainViewModel)
        {
            _context = context;
            _questService = questService;
            _mainViewModel = mainViewModel;
        }

        public async Task<bool> RegisterUser(string username, string email, string password)
        {

            string verificationCode = GenerateVerificationCode();

            try
            {
                EmailHelper.SendVerificationCode(email, verificationCode, "Реєстрація", "Ви запросили реєстрацію свого акаунту в системі Подорож мініатюрним Ужгородом.");
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(Strings.ErrorSendingMail + ex.Message);
                return false;
            }

            ShowSuccessMessageBox($"{Strings.CodeSent} {email}");

            if (!PromptForVerificationCode(verificationCode))
            {
                ShowErrorMessageBox(Strings.InvalidCode);
                return false;
            }

            string hashedPassword = PasswordHelper.HashPassword(password);

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = hashedPassword,
                Role = UserRole.User,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            _questService.InitializeFirstQuestForUser(user.Id);

            SaveUserInSettings(username);
            _mainViewModel.OnPropertyChanged(nameof(_mainViewModel.IsLoggedIn));
            return true;
        }

        public async Task<User?> LoginUser(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user != null && PasswordHelper.VerifyPassword(password, user.PasswordHash))
            {
                SaveUserInSettings(username);
                _mainViewModel.OnPropertyChanged(nameof(_mainViewModel.IsLoggedIn));
                return user;
            }

            return null;
        }

        public static void SaveUserInSettings(string username)
        {
            Settings.Default.username = username;
            Settings.Default.Save();
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

        private string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private bool PromptForVerificationCode(string correctCode)
        {
            MessageBoxView messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = Strings.EnterCode;
            messageBoxView.MessageBoxTextBox.Visibility = Visibility.Visible;
            messageBoxView.MessageBoxTextBox.Margin = new Thickness(0, 0, 10, 0);
            messageBoxView.ButtonYes.Visibility = Visibility.Hidden;
            messageBoxView.ButtonNo.Visibility = Visibility.Hidden;
            messageBoxView.ButtonOk.Visibility = Visibility.Visible;
            messageBoxView.ButtonOk.Content = "Перевірити";
            messageBoxView.ButtonOk.Margin = new Thickness(10);
            messageBoxView.IconSuccess.Visibility = Visibility.Hidden;
            messageBoxView.IconThink.Visibility = Visibility.Visible;
            messageBoxView.IconError.Visibility = Visibility.Hidden;


            string enteredCode = null;
            messageBoxView.MessageBoxTextBox.TextChanged += (sender, e) =>
            {
                enteredCode = messageBoxView.MessageBoxTextBox.Text;
            };

            messageBoxView.ShowDialog();

            return enteredCode == correctCode;
        }
    }
}