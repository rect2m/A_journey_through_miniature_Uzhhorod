using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Service;
using A_journey_through_miniature_Uzhhorod.MVVM.View;
using A_journey_through_miniature_Uzhhorod.Properties;
using A_journey_through_miniature_Uzhhorod.Resources;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    public class FeedbackViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;
        private readonly QuestService _questService;

        public string Message { get; set; }

        public ObservableCollection<string> Categories { get; set; } = new();

        private string _category;
        public string Category
        {
            get => _category;
            set { _category = value; OnPropertyChanged(nameof(Category)); }
        }

        public ICommand SendFeedbackCommand { get; }

        public FeedbackViewModel(IAppDbContextFactory contextFactory, QuestService questService)
        {
            _contextFactory = contextFactory;
            _questService = questService;

            SendFeedbackCommand = new ViewModelCommand(SendFeedback);

            UpdateCategories();

            LanguageManager.LanguageChanged += UpdateCategories;
        }

        private void UpdateCategories()
        {
            Categories.Clear();
            Categories.Add(Strings.FeedbackCategorySuggestion); // Пропозиція / Suggestion
            Categories.Add(Strings.FeedbackCategoryError);      // Помилка / Error
            Categories.Add(Strings.FeedbackCategoryOther);      // Інше / Other
        }

        private void SendFeedback(object obj)
        {
            if (string.IsNullOrWhiteSpace(Category))
            {
                ShowErrorMessageBox(Strings.FeedbackSelectCategory);
                return;
            }

            if (string.IsNullOrWhiteSpace(Message))
            {
                ShowErrorMessageBox(Strings.FeedbackEnterMessage);
                return;
            }

            using var context = _contextFactory.CreateContext();

            var username = Settings.Default.username;
            var user = context.Users.FirstOrDefault(u => u.Username == username);

            var feedback = new Feedback
            {
                UserId = user?.Id,
                Email = user?.Email ?? "Не вказано",
                Category = Category,
                Message = Message
            };

            context.Feedbacks.Add(feedback);
            context.SaveChanges();

            if (user != null)
            {
                _questService.UpdateQuestProgress(user.Id, "SendFeedback");
                _questService.UpdateQuestProgress(user.Id, "Send5Feedbacks");
                _questService.UpdateQuestProgress(user.Id, "Send10Feedbacks");
                _questService.UpdateQuestProgress(user.Id, "Send30Feedbacks");
            }

            ShowSuccessMessageBox(Strings.FeedbackSuccessMessage);
            Message = string.Empty;
            OnPropertyChanged(nameof(Message));
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
