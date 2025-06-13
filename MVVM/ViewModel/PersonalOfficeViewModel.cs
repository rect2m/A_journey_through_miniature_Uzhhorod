using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.Database.Models.Translation;
using A_journey_through_miniature_Uzhhorod.MVVM.Model;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Service;
using A_journey_through_miniature_Uzhhorod.MVVM.View;
using A_journey_through_miniature_Uzhhorod.Properties;
using A_journey_through_miniature_Uzhhorod.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    public class UserActivityViewModel
    {
        public string Action { get; set; }
        public string Details { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class PersonalOfficeViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;
        private string activeUser;
        private readonly BlobStorageService _blobStorageService;
        // private readonly string _avatarContainer = "avatars";

        public bool deleteVerCode = false;

        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }

        private int _currentReviewPage = 1;
        private int _currentActivityPage = 1;
        private int _currentFeedbackPage = 1;
        private const int PageSize = 10;

        private List<ReviewViewModel> _allReviews = new();
        private List<UserActivity> _allActivities = new();
        private List<UserActivity> _filteredActivities = new();
        private List<FeedbackViewModel> _allFeedbacks = new();

        public ObservableCollection<ReviewViewModel> UserReviews { get; set; } = new();
        public ObservableCollection<(string Title, string Description, DateTime EarnedAt)> UserAchievements { get; set; } = new();
        public ObservableCollection<UserActivityViewModel> UserActivities { get; set; } = new();
        public ObservableCollection<FeedbackViewModel> UserFeedbacks { get; set; } = new();

        public int CurrentFeedbackPage
        {
            get => _currentFeedbackPage;
            set
            {
                _currentFeedbackPage = value;
                OnPropertyChanged(nameof(CurrentFeedbackPage));
                LoadPagedFeedbacks();
            }
        }

        public int TotalFeedbackPages => (int)Math.Ceiling((double)_allFeedbacks.Count / PageSize);

        public ICommand NextFeedbackPageCommand => new ViewModelCommand(_ => { if (CurrentFeedbackPage < TotalFeedbackPages) CurrentFeedbackPage++; });
        public ICommand PrevFeedbackPageCommand => new ViewModelCommand(_ => { if (CurrentFeedbackPage > 1) CurrentFeedbackPage--; });

        public ICommand DeleteFeedbackCommand => new ViewModelCommand(DeleteFeedback);

        public ObservableCollection<string> ActivityFilters { get; set; } = new();

        private string _selectedFilter;
        public string SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                if (_selectedFilter != value)
                {
                    _selectedFilter = value;
                    OnPropertyChanged(nameof(SelectedFilter));
                    FilterActivities();
                }
            }
        }

        public int CurrentReviewPage
        {
            get => _currentReviewPage;
            set
            {
                _currentReviewPage = value;
                OnPropertyChanged(nameof(CurrentReviewPage));
                LoadPagedReviews();
            }
        }

        public int CurrentActivityPage
        {
            get => _currentActivityPage;
            set
            {
                _currentActivityPage = value;
                OnPropertyChanged(nameof(CurrentActivityPage));
                LoadPagedActivities();
            }
        }

        public int TotalReviewPages => (int)Math.Ceiling((double)_allReviews.Count / PageSize);
        public int TotalActivityPages => (int)Math.Ceiling((double)_filteredActivities.Count / PageSize);

        public ICommand NextReviewPageCommand => new ViewModelCommand(_ => { if (CurrentReviewPage < TotalReviewPages) CurrentReviewPage++; });
        public ICommand PrevReviewPageCommand => new ViewModelCommand(_ => { if (CurrentReviewPage > 1) CurrentReviewPage--; });
        public ICommand NextActivityPageCommand => new ViewModelCommand(_ => { if (CurrentActivityPage < TotalActivityPages) CurrentActivityPage++; });
        public ICommand PrevActivityPageCommand => new ViewModelCommand(_ => { if (CurrentActivityPage > 1) CurrentActivityPage--; });

        private string _newUsername;
        public string NewUsername
        {
            get => _newUsername;
            set { _newUsername = value; OnPropertyChanged(nameof(NewUsername)); }
        }

        private string _newEmail;
        public string NewEmail
        {
            get => _newEmail;
            set { _newEmail = value; OnPropertyChanged(nameof(NewEmail)); }
        }

        private string _oldPassword;
        public string OldPassword
        {
            get => _oldPassword;
            set { _oldPassword = value; OnPropertyChanged(nameof(OldPassword)); }
        }

        private string _newPassword;
        public string NewPassword
        {
            get => _newPassword;
            set { _newPassword = value; OnPropertyChanged(nameof(NewPassword)); }
        }

        private string _avatarPath;
        public string AvatarPath
        {
            get => _avatarPath;
            set { _avatarPath = value; OnPropertyChanged(nameof(AvatarPath)); }
        }

        private ObservableCollection<string> _displayOptions = new();
        public ObservableCollection<string> DisplayOptions
        {
            get => _displayOptions;
            set { _displayOptions = value; OnPropertyChanged(nameof(DisplayOptions)); }
        }

        private string _selectedDisplayOption;
        public string SelectedDisplayOption
        {
            get => _selectedDisplayOption;
            set
            {
                if (_selectedDisplayOption != value)
                {
                    _selectedDisplayOption = value;
                    OnPropertyChanged(nameof(SelectedDisplayOption));
                    OnPropertyChanged(nameof(IsReviewSelected));
                    OnPropertyChanged(nameof(IsActivitySelected));
                    OnPropertyChanged(nameof(IsFeedbackSelected));
                }
            }
        }

        public bool IsReviewSelected => SelectedDisplayOption == Strings.Reviews;
        public bool IsActivitySelected => SelectedDisplayOption == Strings.Activity;
        public bool IsFeedbackSelected => SelectedDisplayOption == Strings.Feedback;

        public ICommand UpdateProfileCommand { get; }
        public ICommand ChangeAvatarCommand { get; }
        public ICommand ClearHistoryCommand { get; }
        public ICommand DeleteReviewCommand { get; }
        public ICommand ClearAllReviewsCommand { get; }
        public ICommand DeleteSingleActivityCommand { get; }

        public PersonalOfficeViewModel(IAppDbContextFactory contextFactory, BlobStorageService blobService)
        {
            _contextFactory = contextFactory;
            _blobStorageService = blobService;

            UpdateProfileCommand = new ViewModelCommand(UpdateProfile);
            ChangeAvatarCommand = new ViewModelCommand(ChangeAvatar);
            ClearHistoryCommand = new ViewModelCommand(ClearHistory);
            DeleteReviewCommand = new ViewModelCommand(DeleteReview);
            ClearAllReviewsCommand = new ViewModelCommand(ClearAllReviews);
            DeleteSingleActivityCommand = new ViewModelCommand(DeleteSingleActivity);

            LanguageManager.LanguageChanged += () =>
            {
                UpdateFilterOptions();
                UpdateDisplayOptions();
                LoadUserData();
                LoadUserActivities();
                LoadUserFeedbacks();
            };

            UpdateDisplayOptions();
            SelectedDisplayOption = DisplayOptions.FirstOrDefault() ?? string.Empty;

            UpdateFilterOptions();
            LoadUserData();
            LoadUserActivities();
            LoadUserFeedbacks();
        }

        private void UpdateDisplayOptions()
        {
            var current = SelectedDisplayOption;

            DisplayOptions.Clear();
            DisplayOptions.Add(Strings.Reviews);
            DisplayOptions.Add(Strings.Activity);
            DisplayOptions.Add(Strings.Feedback);

            SelectedDisplayOption = DisplayOptions.Contains(current) ? current : DisplayOptions[0];
        }

        public void LoadUserFeedbacks()
        {
            using var context = _contextFactory.CreateContext();
            var user = context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
            if (user != null)
            {
                var feedbacks = context.Feedbacks
                    .Include(f => f.User)
                    .Where(f => f.UserId == user.Id)
                    .OrderByDescending(f => f.SentAt)
                    .ToList();

                _allFeedbacks = feedbacks.Select(feedback => new FeedbackViewModel
                {
                    Id = feedback.Id,
                    Username = feedback.User?.Username ?? "Анонім",
                    Email = feedback.Email,
                    Category = TranslateCategory(feedback.Category),
                    Message = feedback.Message,
                    SentAt = feedback.SentAt,
                    AdminResponse = feedback.AdminResponse
                }).ToList();

                LoadPagedFeedbacks();
                OnPropertyChanged(nameof(UserFeedbacks));
            }
        }

        private string TranslateCategory(string category)
        {
            return LanguageManager.CurrentLanguage switch
            {
                "en" => category switch
                {
                    "Пропозиція" => "Suggestion",
                    "Помилка" => "Bug",
                    "Інше" => "Other",
                    _ => category
                },
                "uk" => category switch
                {
                    "Suggestion" => "Пропозиція",
                    "Bug" => "Помилка",
                    "Other" => "Інше",
                    _ => category
                },
                _ => category
            };
        }

        private void LoadPagedFeedbacks()
        {
            UserFeedbacks.Clear();
            foreach (var feedback in _allFeedbacks.Skip((CurrentFeedbackPage - 1) * PageSize).Take(PageSize))
            {
                UserFeedbacks.Add(feedback);
            }
            OnPropertyChanged(nameof(TotalFeedbackPages));
        }

        private void DeleteFeedback(object obj)
        {
            MessageBoxView messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = Strings.DeleteFeedback;
            messageBoxView.ButtonYes.Content = Strings.Yes;
            messageBoxView.ButtonOk.Content = Strings.No;
            messageBoxView.ButtonYes.Visibility = Visibility.Visible;
            messageBoxView.ButtonNo.Visibility = Visibility.Hidden;
            messageBoxView.ButtonOk.Visibility = Visibility.Visible;
            messageBoxView.IconSuccess.Visibility = Visibility.Hidden;
            messageBoxView.IconThink.Visibility = Visibility.Visible;
            messageBoxView.IconError.Visibility = Visibility.Hidden;
            messageBoxView.ShowDialog();

            if (MessageBoxView.buttonYesClicked == true && obj is FeedbackViewModel vm)
            {
                using var context = _contextFactory.CreateContext();
                var feedback = context.Feedbacks.FirstOrDefault(f => f.Id == vm.Id);
                if (feedback != null)
                {
                    context.Feedbacks.Remove(feedback);
                    context.SaveChanges();

                    _allFeedbacks.Remove(vm);
                    LoadPagedFeedbacks();
                    ShowSuccessMessageBox(Strings.FeedbackRemoved);
                    MessageBoxView.buttonYesClicked = false;
                }
            }
        }

        private void UpdateFilterOptions()
        {
            var oldFilter = SelectedFilter;
            ActivityFilters.Clear();

            ActivityFilters.Add(Resources.Strings.Filter_All);
            ActivityFilters.Add(Resources.Strings.Filter_View);
            ActivityFilters.Add(Resources.Strings.Filter_Rating);
            ActivityFilters.Add(Resources.Strings.Filter_Review);
            ActivityFilters.Add(Resources.Strings.Filter_Quest);
            ActivityFilters.Add(Resources.Strings.Filter_Achievement);

            SelectedFilter = ActivityFilters.Contains(oldFilter) ? oldFilter : ActivityFilters[0];
        }

        public void LoadUserData()
        {
            activeUser = Settings.Default.username;

            using var context = _contextFactory.CreateContext();

            CurrentUser = context.Users
                .Include(u => u.Reviews)
                    .ThenInclude(r => r.Miniature)
                        .ThenInclude(m => m.Translations)
                .Include(u => u.UserAchievements)
                    .ThenInclude(ua => ua.Achievement)
                        .ThenInclude(a => a.Translations)
                .FirstOrDefault(u => u.Username == activeUser);

            if (CurrentUser != null)
            {
                NewUsername = CurrentUser.Username;
                NewEmail = CurrentUser.Email;

                // Використання аватара з Azure Blob Storage
                if (!string.IsNullOrWhiteSpace(CurrentUser.AvatarUrl))
                {
                    AvatarPath = _blobStorageService.GetBlobUrl(CurrentUser.AvatarUrl, "avatars");
                }
                else
                {
                    AvatarPath = "https://minisculptures.blob.core.windows.net/avatars/avatar.png";
                }

                _allReviews = CurrentUser.Reviews.Select(review =>
                {
                    string languageCode = LanguageManager.CurrentLanguage;
                    string miniatureName = review.Miniature.Translations
                        .FirstOrDefault(t => t.LanguageCode == languageCode)?.Name
                        ?? review.Miniature.Translations.FirstOrDefault()?.Name
                        ?? "Unknown miniature";

                    return new ReviewViewModel
                    {
                        Id = review.Id,
                        UserName = CurrentUser.Username,
                        MiniatureName = miniatureName,
                        Comment = review.Comment,
                        Rating = review.Rating,
                        CreatedAt = review.CreatedAt
                    };
                }).ToList();

                CurrentReviewPage = 1;
            }
            else
            {
                AvatarPath = "https://minisculptures.blob.core.windows.net/avatars/avatar.png";
            }
        }

        public void LoadUserActivities()
        {
            using var context = _contextFactory.CreateContext();
            var user = context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
            if (user != null)
            {
                _allActivities = context.UserActivities
                    .Where(a => a.UserId == user.Id)
                    .Include(a => a.Translations)
                    .OrderByDescending(a => a.Timestamp)
                    .ToList();

                FilterActivities();
            }
        }

        private void FilterActivities()
        {
            IEnumerable<UserActivity> filtered = _allActivities;
            string lang = LanguageManager.CurrentLanguage;

            if (SelectedFilter != Resources.Strings.Filter_All)
            {
                if (SelectedFilter == Resources.Strings.Filter_View)
                {
                    filtered = filtered.Where(a => a.Translations.FirstOrDefault(t => t.LanguageCode == lang)?.Action.Contains("перегляд", StringComparison.OrdinalIgnoreCase) == true ||
                                                   a.Translations.FirstOrDefault(t => t.LanguageCode == lang)?.Action.Contains("view", StringComparison.OrdinalIgnoreCase) == true);
                }
                else if (SelectedFilter == Resources.Strings.Filter_Review)
                {
                    filtered = filtered.Where(a => a.Translations.FirstOrDefault(t => t.LanguageCode == lang)?.Action.Contains("відгук", StringComparison.OrdinalIgnoreCase) == true ||
                                                   a.Translations.FirstOrDefault(t => t.LanguageCode == lang)?.Action.Contains("review", StringComparison.OrdinalIgnoreCase) == true);
                }
                else if (SelectedFilter == Resources.Strings.Filter_Rating)
                {
                    filtered = filtered.Where(a => a.Translations.FirstOrDefault(t => t.LanguageCode == lang)?.Action.Contains("оцінювання", StringComparison.OrdinalIgnoreCase) == true ||
                                                   a.Translations.FirstOrDefault(t => t.LanguageCode == lang)?.Action.Contains("rating", StringComparison.OrdinalIgnoreCase) == true);
                }
                else if (SelectedFilter == Resources.Strings.Filter_Quest)
                {
                    filtered = filtered.Where(a => a.Translations.FirstOrDefault(t => t.LanguageCode == lang)?.Action.Contains("квест", StringComparison.OrdinalIgnoreCase) == true ||
                                                   a.Translations.FirstOrDefault(t => t.LanguageCode == lang)?.Action.Contains("quest", StringComparison.OrdinalIgnoreCase) == true);
                }
                else if (SelectedFilter == Resources.Strings.Filter_Achievement)
                {
                    filtered = filtered.Where(a => a.Translations.FirstOrDefault(t => t.LanguageCode == lang)?.Action.Contains("досягнення", StringComparison.OrdinalIgnoreCase) == true ||
                                                   a.Translations.FirstOrDefault(t => t.LanguageCode == lang)?.Action.Contains("achievement", StringComparison.OrdinalIgnoreCase) == true);
                }
            }

            _filteredActivities = filtered.ToList();

            CurrentActivityPage = 1;
            OnPropertyChanged(nameof(TotalActivityPages));
            LoadPagedActivities();
        }

        private void LoadPagedActivities()
        {
            string lang = LanguageManager.CurrentLanguage;
            UserActivities.Clear();

            foreach (var activity in _filteredActivities.Skip((CurrentActivityPage - 1) * PageSize).Take(PageSize))
            {
                var translation = activity.Translations.FirstOrDefault(t => t.LanguageCode == lang);
                string action = translation?.Action ?? "—";
                string details = translation?.Details ?? "—";

                if (action == "Перегляд скульптурки" && int.TryParse(details, out int miniatureId))
                {
                    using var context = _contextFactory.CreateContext();
                    var miniTranslation = context.Miniatures
                        .Include(m => m.Translations)
                        .FirstOrDefault(m => m.Id == miniatureId)?
                        .Translations.FirstOrDefault(t => t.LanguageCode == lang);

                    if (miniTranslation != null)
                        details = miniTranslation.Name;
                }

                UserActivities.Add(new UserActivityViewModel
                {
                    Action = action,
                    Details = details,
                    Timestamp = activity.Timestamp
                });
            }

            OnPropertyChanged(nameof(TotalActivityPages));
        }

        private void LoadPagedReviews()
        {
            UserReviews.Clear();
            foreach (var review in _allReviews.Skip((CurrentReviewPage - 1) * PageSize).Take(PageSize))
            {
                UserReviews.Add(review);
            }
            OnPropertyChanged(nameof(TotalReviewPages));
        }

        private void ClearHistory(object obj)
        {
            using var context = _contextFactory.CreateContext();

            MessageBoxView messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = Strings.ClearHistory;
            messageBoxView.ButtonYes.Content = Strings.Yes;
            messageBoxView.ButtonOk.Content = Strings.No;
            messageBoxView.ButtonYes.Visibility = Visibility.Visible;
            messageBoxView.ButtonNo.Visibility = Visibility.Hidden;
            messageBoxView.ButtonOk.Visibility = Visibility.Visible;
            messageBoxView.IconSuccess.Visibility = Visibility.Hidden;
            messageBoxView.IconThink.Visibility = Visibility.Visible;
            messageBoxView.IconError.Visibility = Visibility.Hidden;
            messageBoxView.ShowDialog();

            if (MessageBoxView.buttonYesClicked == true)
            {
                if (CurrentUser == null) return;

                var activitiesToRemove = context.UserActivities
                    .Where(a => a.UserId == CurrentUser.Id)
                    .ToList();

                context.UserActivities.RemoveRange(activitiesToRemove);
                context.SaveChanges();

                UserActivities.Clear();
                MessageBoxView.buttonYesClicked = false;
            }
        }

        private void DeleteSingleActivity(object obj)
        {
            MessageBoxView messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = Strings.ClearRecord;
            messageBoxView.ButtonYes.Content = Strings.Yes;
            messageBoxView.ButtonOk.Content = Strings.No;
            messageBoxView.ButtonYes.Visibility = Visibility.Visible;
            messageBoxView.ButtonNo.Visibility = Visibility.Hidden;
            messageBoxView.ButtonOk.Visibility = Visibility.Visible;
            messageBoxView.IconSuccess.Visibility = Visibility.Hidden;
            messageBoxView.IconThink.Visibility = Visibility.Visible;
            messageBoxView.IconError.Visibility = Visibility.Hidden;
            messageBoxView.ShowDialog();

            if (MessageBoxView.buttonYesClicked == true)
            {
                if (obj is UserActivityViewModel vm)
                {
                    using var context = _contextFactory.CreateContext();
                    var user = context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
                    if (user == null) return;

                    var activity = context.UserActivities
                        .Include(a => a.Translations)
                        .FirstOrDefault(a => a.UserId == user.Id && a.Timestamp == vm.Timestamp);

                    if (activity != null)
                    {
                        context.UserActivities.Remove(activity);
                        context.SaveChanges();

                        UserActivities.Remove(vm);
                        ShowSuccessMessageBox(Strings.RecordRemoved);
                    }

                    MessageBoxView.buttonYesClicked = false;
                }
            }
        }

        private void DeleteReview(object obj)
        {
            MessageBoxView messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = Strings.DeleteReview;
            messageBoxView.ButtonYes.Content = Strings.Yes;
            messageBoxView.ButtonOk.Content = Strings.No;
            messageBoxView.ButtonYes.Visibility = Visibility.Visible;
            messageBoxView.ButtonNo.Visibility = Visibility.Hidden;
            messageBoxView.ButtonOk.Visibility = Visibility.Visible;
            messageBoxView.IconSuccess.Visibility = Visibility.Hidden;
            messageBoxView.IconThink.Visibility = Visibility.Visible;
            messageBoxView.IconError.Visibility = Visibility.Hidden;
            messageBoxView.ShowDialog();

            if (MessageBoxView.buttonYesClicked == true)
            {
                if (obj is ReviewViewModel reviewVm)
                {
                    using var context = _contextFactory.CreateContext();
                    var review = context.Reviews.FirstOrDefault(r => r.Id == reviewVm.Id);
                    if (review != null)
                    {
                        context.Reviews.Remove(review);
                        context.SaveChanges();

                        UserReviews.Remove(reviewVm);
                        ShowSuccessMessageBox(Strings.ReviewRemoved);
                        MessageBoxView.buttonYesClicked = false;
                    }
                }
            }
        }

        private void ClearAllReviews(object obj)
        {
            MessageBoxView messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = Strings.RemoveReviews;
            messageBoxView.ButtonYes.Content = Strings.Yes;
            messageBoxView.ButtonOk.Content = Strings.No;
            messageBoxView.ButtonYes.Visibility = Visibility.Visible;
            messageBoxView.ButtonNo.Visibility = Visibility.Hidden;
            messageBoxView.ButtonOk.Visibility = Visibility.Visible;
            messageBoxView.IconSuccess.Visibility = Visibility.Hidden;
            messageBoxView.IconThink.Visibility = Visibility.Visible;
            messageBoxView.IconError.Visibility = Visibility.Hidden;
            messageBoxView.ShowDialog();

            if (MessageBoxView.buttonYesClicked == true)
            {
                if (CurrentUser == null) return;

                using var context = _contextFactory.CreateContext();

                var reviewsToRemove = context.Reviews
                    .Where(r => r.UserId == CurrentUser.Id)
                    .ToList();

                if (reviewsToRemove.Any())
                {
                    context.Reviews.RemoveRange(reviewsToRemove);
                    context.SaveChanges();

                    UserReviews.Clear();
                    ShowSuccessMessageBox(Strings.AllReviewsRemoved);
                    MessageBoxView.buttonYesClicked = false;
                }
            }
        }

        public class FeedbackViewModel
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Category { get; set; }
            public string Message { get; set; }
            public DateTime SentAt { get; set; }
            public string? AdminResponse { get; set; }
        }

        public class ReviewViewModel
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string MiniatureName { get; set; }
            public string Comment { get; set; }
            public int Rating { get; set; }
            public DateTime CreatedAt { get; set; }
        }

        private async void ChangeAvatar(object obj)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Зображення (*.jpg;*.png)|*.jpg;*.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                using var context = _contextFactory.CreateContext();

                var user = context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
                if (user == null) return;

                string previousAvatar = user.AvatarUrl;

                // унікальне ім’я для нового файлу
                string newFileName = $"{Settings.Default.username}_{Guid.NewGuid()}{Path.GetExtension(openFileDialog.FileName)}";

                // Завантаження нового аватара
                await using var stream = File.OpenRead(openFileDialog.FileName);
                await _blobStorageService.UploadFileAsync(stream, newFileName, "avatars");

                // Оновлення URL в базі
                user.AvatarUrl = newFileName;
                context.SaveChanges();

                // Видалення попереднього аватара, якщо це не заглушка
                if (!string.IsNullOrWhiteSpace(previousAvatar) && previousAvatar != "avatar.png")
                {
                    await _blobStorageService.DeleteFileAsync(previousAvatar, "avatars");
                }

                AvatarPath = _blobStorageService.GetBlobUrl(newFileName, "avatars");
                LogUserActivity("Зміна аватару", "Avatar change");
                CurrentUser = user;

                Application.Current.Dispatcher.Invoke(() =>
                {
                    MainWindowView.Instance?.LoadUserData();
                });
            }
        }

        private void UpdateProfile(object obj)
        {
            using var context = _contextFactory.CreateContext();

            var user = context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
            if (user == null) return;

            if (!string.IsNullOrWhiteSpace(NewUsername) && NewUsername != user.Username)
            {
                if (!Validator.IsValidUsername(NewUsername))
                {
                    ShowErrorMessageBox(Strings.UsernameValidation);
                    return;
                }
                if (context.Users.Any(u => u.Username == NewUsername))
                {
                    ShowErrorMessageBox(Strings.UsernameTaken);
                    return;
                }
                user.Username = NewUsername;
            }

            if (!string.IsNullOrWhiteSpace(NewEmail) && NewEmail != user.Email)
            {
                if (!Validator.IsValidEmail(NewEmail))
                {
                    ShowErrorMessageBox(Strings.IncorrectEmailFormat);
                    return;
                }

                if (context.Users.Any(u => u.Email == NewEmail && u.Id != user.Id))
                {
                    ShowErrorMessageBox(Strings.EmailAlredyExist);
                    return;
                }

                string verificationCode = GenerateVerificationCode();
                EmailHelper.SendVerificationCode(user.Email, verificationCode, "Зміна електронної пошти",
                    $"Ви намагаєтесь змінити електронну пошту на {NewEmail}. Щоб підтвердити, введіть код:");

                ShowSuccessMessageBox($"{Strings.CodeSent} {user.Email}");

                if (!PromptForVerificationCode(verificationCode))
                {
                    ShowErrorMessageBox(Strings.InvalidCodeDelete);
                    return;
                }

                user.Email = NewEmail;
            }

            if (!string.IsNullOrWhiteSpace(OldPassword) && !string.IsNullOrWhiteSpace(NewPassword))
            {
                if (!PasswordHelper.VerifyPassword(OldPassword, user.PasswordHash))
                {
                    ShowErrorMessageBox(Strings.IncorrectOldPassword);
                    return;
                }
                if (!Validator.IsValidPassword(NewPassword))
                {
                    ShowErrorMessageBox(Strings.PasswordValidation);
                    return;
                }

                string verificationCode = GenerateVerificationCode();
                EmailHelper.SendVerificationCode(user.Email, verificationCode, "Зміна пароля", "Ви запросили зміну пароля в системі Подорож мініатюрним Ужгородом.");
                ShowSuccessMessageBox($"Код підтвердження надіслано на {user.Email}");

                if (!PromptForVerificationCode(verificationCode))
                {
                    ShowErrorMessageBox(Strings.POInvalidCode);
                    return;
                }

                user.PasswordHash = PasswordHelper.HashPassword(NewPassword);
            }
            else if (!string.IsNullOrWhiteSpace(NewPassword))
            {
                ShowErrorMessageBox(Strings.EnterOldPassword);
                return;
            }

            if (!string.IsNullOrWhiteSpace(AvatarPath))
                user.AvatarUrl = Path.GetFileName(AvatarPath);

            context.SaveChanges();
            SaveUserInSettings(user.Username);
            CurrentUser = user; // оновлюємо
            LoadUserData();
            MainWindowView.Instance?.LoadUserData();
            LogUserActivity("Редагування даних", "Profile update");
            ShowSuccessMessageBox(Strings.ProfileUpdated);
        }

        public async void DeleteAccount()
        {
            if (CurrentUser == null)
            {
                ShowErrorMessageBox(Strings.UserNotFound);
                return;
            }

            try
            {
                string email = CurrentUser.Email;
                using var context = _contextFactory.CreateContext();

                string verificationCode = GenerateVerificationCode();
                EmailHelper.SendVerificationCode(email, verificationCode, "Видалення акаунту", "Ви запросили видалення свого акаунту в системі Подорож мініатюрним Ужгородом.");
                ShowSuccessMessageBox($"Код підтвердження надіслано на {email}");

                if (!PromptForVerificationCode(verificationCode))
                {
                    ShowErrorMessageBox(Strings.InvalidCodeDelete);
                    deleteVerCode = false;
                    return;
                }

                // Завантажити користувача з пов’язаними об’єктами заново
                var user = context.Users
                    .Include(u => u.Reviews)
                    .Include(u => u.UserAchievements)
                    .FirstOrDefault(u => u.Id == CurrentUser.Id);

                if (user == null)
                {
                    ShowErrorMessageBox(Strings.UserNotFound);
                    return;
                }

                Settings.Default.username = string.Empty;
                Settings.Default.Save();

                if (!string.IsNullOrWhiteSpace(user.AvatarUrl) && user.AvatarUrl != "avatar.png")
                {
                    try
                    {
                        await _blobStorageService.DeleteFileAsync(user.AvatarUrl, "avatars");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка видалення аватара з Blob Storage: {ex.Message}");
                    }
                }

                context.Reviews.RemoveRange(user.Reviews ?? new List<Review>());
                context.UserAchievements.RemoveRange(user.UserAchievements ?? new List<UserAchievement>());
                context.Users.Remove(user);
                context.SaveChanges();

                deleteVerCode = true;
                ShowSuccessMessageBox(Strings.AccountDeleted);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    MainWindowView.Instance?.SetGuestMode();
                    MainWindowView.Instance?.RadioButtonHome_Check();
                });
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox(Strings.ErrorAccountDelete + "\n\n" + ex.Message);
            }
        }

        public void Logout()
        {
            Settings.Default.username = string.Empty;
            Settings.Default.Save();

            MainWindowView.Instance?.SetGuestMode();
            MainWindowView.Instance?.LoadUserData();
            MainWindowView.Instance?.RadioButtonHome_Check();

            LoadUserData();
        }

        public void LogUserActivity(string actionUk, string actionEn, string detailsUk = "", string detailsEn = "")
        {
            using var context = _contextFactory.CreateContext();

            var user = context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
            if (user != null)
            {
                CleanupUserActivities(user.Id);

                var activity = new UserActivity
                {
                    UserId = user.Id,
                    Timestamp = DateTime.UtcNow.AddHours(3),
                    Translations = new List<UserActivityTranslation>
                    {
                        new UserActivityTranslation
                        {
                            LanguageCode = "uk",
                            Action = actionUk,
                            Details = detailsUk
                        },
                        new UserActivityTranslation
                        {
                            LanguageCode = "en",
                            Action = actionEn,
                            Details = detailsEn
                        }
                    }
                };

                context.UserActivities.Add(activity);
                context.SaveChanges();
            }
        }

        private void CleanupUserActivities(int userId)
        {
            using var context = _contextFactory.CreateContext();

            var cutoffDate = DateTime.UtcNow.AddMonths(-6);
            var oldRecords = context.UserActivities
                .Where(a => a.UserId == userId && a.Timestamp < cutoffDate)
                .ToList();

            context.UserActivities.RemoveRange(oldRecords);

            var excessRecords = context.UserActivities
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.Timestamp)
                .Skip(100)
                .ToList();

            context.UserActivities.RemoveRange(excessRecords);

            context.SaveChanges();
        }

        public static void SaveUserInSettings(string username)
        {
            Settings.Default.username = username;
            Settings.Default.Save();
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
            messageBoxView.ButtonOk.Content = Strings.Verify;
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
