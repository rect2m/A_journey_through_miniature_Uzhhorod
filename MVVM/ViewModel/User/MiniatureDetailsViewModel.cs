using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.Database.Models.Translation;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Service;
using A_journey_through_miniature_Uzhhorod.MVVM.View;
using A_journey_through_miniature_Uzhhorod.Properties;
using A_journey_through_miniature_Uzhhorod.Resources;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static A_journey_through_miniature_Uzhhorod.MVVM.ViewModel.MiniaturesViewModel;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    public class MiniatureDetailsViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;
        private MiniatureViewModel _selectedMiniature;
        private readonly QuestService _questService;
        private string _reviewComment;
        private string _currentLanguage => Settings.Default.LanguageCode;

        public ObservableCollection<ReviewViewModel> Reviews { get; set; } = new();

        public MiniatureViewModel SelectedMiniature
        {
            get => _selectedMiniature;
            set
            {
                _selectedMiniature = value;
                if (_selectedMiniature != null)
                {
                    _selectedMiniature.ModelUrl = _selectedMiniature.ModelUrl?.Replace("\\", "/");
                }
                OnPropertyChanged(nameof(SelectedMiniature));
                ReloadMiniatureDetails();
            }
        }

        public string ReviewComment
        {
            get => _reviewComment;
            set
            {
                _reviewComment = value;
                OnPropertyChanged(nameof(ReviewComment));
            }
        }

        public ICommand RateCommand { get; }
        public ICommand SubmitReviewCommand { get; }
        public ICommand BackToListCommand { get; }
        public ICommand View3DModelCommand { get; }
        public ICommand ToggleFavoriteCommand { get; }

        public event Action<ViewModelBase> OnNavigateBack;

        public MiniatureDetailsViewModel(IAppDbContextFactory contextFactory, QuestService questService)
        {
            _contextFactory = contextFactory;
            _questService = questService;

            BackToListCommand = new ViewModelCommand(ExecuteBackToListCommand);
            View3DModelCommand = new ViewModelCommand(ExecuteView3DModelCommand);

            RateCommand = new ViewModelCommand(obj =>
            {
                if (!CheckUserLoggedIn()) return;
                ExecuteRateCommand(obj);
            });

            SubmitReviewCommand = new ViewModelCommand(obj =>
            {
                if (!CheckUserLoggedIn()) return;
                ExecuteSubmitCommentCommand(obj);
            });

            ToggleFavoriteCommand = new ViewModelCommand(obj =>
            {
                if (!CheckUserLoggedIn()) return;
                ExecuteToggleFavoriteCommand(obj);
            });

            LanguageManager.LanguageChanged += () =>
            {
                ReloadMiniatureDetails();
            };
        }

        private bool CheckUserLoggedIn()
        {
            if (string.IsNullOrEmpty(Settings.Default.username))
            {
                ShowErrorMessageBox(Strings.RegOrLogProfile);
                return false;
            }
            return true;
        }

        public void ReloadMiniatureDetails()
        {
            if (SelectedMiniature == null) return;

            using var context = _contextFactory.CreateContext();
            var miniature = context.Miniatures
                .Include(m => m.Translations)
                .FirstOrDefault(m => m.Id == SelectedMiniature.Id);

            if (miniature != null)
            {
                var translation = miniature.Translations.FirstOrDefault(t => t.LanguageCode == _currentLanguage);
                if (translation != null)
                {
                    SelectedMiniature.Name = translation.Name;
                    SelectedMiniature.Description = translation.Description;
                    OnPropertyChanged(nameof(SelectedMiniature));
                }
            }

            LoadAverageRating();
            LoadReviews();
        }

        private void ExecuteToggleFavoriteCommand(object obj)
        {
            using var context = _contextFactory.CreateContext();

            var username = Settings.Default.username;
            var user = context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null || SelectedMiniature == null) return;

            var fav = context.FavoriteMiniatures
                .FirstOrDefault(f => f.UserId == user.Id && f.MiniatureId == SelectedMiniature.Id);

            if (fav != null)
            {
                context.FavoriteMiniatures.Remove(fav);
                context.SaveChanges();
                SelectedMiniature.IsFavorite = false;
                ShowSuccessMessageBox(Strings.RemoveFavorite);
            }
            else
            {
                context.FavoriteMiniatures.Add(new FavoriteMiniature
                {
                    UserId = user.Id,
                    MiniatureId = SelectedMiniature.Id
                });
                context.SaveChanges();
                SelectedMiniature.IsFavorite = true;
                ShowSuccessMessageBox(Strings.AddFavorite);

                _questService.UpdateFavoriteQuest(user.Id, SelectedMiniature.Id);
            }
        }

        private void ExecuteRateCommand(object rating)
        {
            using var context = _contextFactory.CreateContext();

            string activeUser = Settings.Default.username;

            if (SelectedMiniature == null)
            {
                ShowErrorMessageBox(Strings.ChooseSculpture);
                return;
            }

            if (int.TryParse(rating.ToString(), out int rateValue))
            {
                int? userId = GetUserIdByUsername(context, activeUser);
                if (userId == null)
                {
                    ShowErrorMessageBox(Strings.UserNotFound);
                    return;
                }

                var userReviews = context.Reviews
                    .Where(r => r.MiniatureId == SelectedMiniature.Id && r.UserId == userId.Value)
                    .ToList();

                if (userReviews.Any())
                {
                    foreach (var review in userReviews)
                    {
                        review.Rating = rateValue;
                    }

                    ShowSuccessMessageBox($"{Strings.RatingUpdate} {rateValue} ☆");
                }
                else
                {
                    var newReview = new Review
                    {
                        MiniatureId = SelectedMiniature.Id,
                        UserId = userId.Value,
                        Rating = rateValue,
                        Comment = "",
                        CreatedAt = DateTime.UtcNow.AddHours(3)
                    };
                    context.Reviews.Add(newReview);

                    ShowSuccessMessageBox($"{Strings.YourRating} {rateValue} ☆ {Strings.Saved}");
                }

                context.SaveChanges();
                LogUserActivity(context, "Оцінювання скульптурки", "Rating a miniature", SelectedMiniature.Name, SelectedMiniature.Name);

                _questService.UpdateUniqueQuest(userId.Value, "RateMiniature", SelectedMiniature.Id.ToString());
                _questService.UpdateUniqueQuest(userId.Value, "Rate5Miniatures", SelectedMiniature.Id.ToString());
                _questService.UpdateUniqueQuest(userId.Value, "Rate10Miniatures", SelectedMiniature.Id.ToString());
                _questService.UpdateUniqueQuest(userId.Value, "Rate20Miniatures", SelectedMiniature.Id.ToString());

                LoadAverageRating();
                LoadReviews();
            }
        }

        private void ExecuteSubmitCommentCommand(object obj)
        {
            using var context = _contextFactory.CreateContext();

            string activeUser = Settings.Default.username;

            if (SelectedMiniature == null)
            {
                ShowErrorMessageBox(Strings.ChooseSculpture);
                return;
            }

            if (string.IsNullOrWhiteSpace(ReviewComment))
            {
                ShowErrorMessageBox(Strings.EnterComment);
                return;
            }

            int? userId = GetUserIdByUsername(context, activeUser);
            if (userId == null)
            {
                ShowErrorMessageBox(Strings.UserNotFound);
                return;
            }

            int userRating = context.Reviews
                .Where(r => r.MiniatureId == SelectedMiniature.Id && r.UserId == userId.Value)
                .Select(r => r.Rating)
                .FirstOrDefault();

            var newReview = new Review
            {
                MiniatureId = SelectedMiniature.Id,
                UserId = userId.Value,
                Rating = userRating,
                Comment = ReviewComment,
                CreatedAt = DateTime.UtcNow.AddHours(3)
            };

            context.Reviews.Add(newReview);
            context.SaveChanges();
            LogUserActivity(context, "Написання відгуку", "Writing a review", SelectedMiniature.Name, SelectedMiniature.Name);

            _questService.UpdateUniqueQuest(userId.Value, "WriteReview", newReview.Id.ToString());
            _questService.UpdateUniqueQuest(userId.Value, "Write5Reviews", newReview.Id.ToString());
            _questService.UpdateUniqueQuest(userId.Value, "Write10Reviews", newReview.Id.ToString());
            _questService.UpdateUniqueQuest(userId.Value, "Write20Reviews", newReview.Id.ToString());

            ShowSuccessMessageBox(Strings.ReviewSaved);

            ReviewComment = string.Empty;
            LoadReviews();
        }

        private void LoadAverageRating()
        {
            using var context = _contextFactory.CreateContext();

            if (SelectedMiniature != null)
            {
                var reviews = context.Reviews.Where(r => r.MiniatureId == SelectedMiniature.Id);
                SelectedMiniature.AverageRating = reviews.Any() ? reviews.Average(r => r.Rating) : 0;
            }
        }

        private void LoadReviews()
        {
            using var context = _contextFactory.CreateContext();

            if (SelectedMiniature != null)
            {
                Reviews.Clear();

                var reviews = context.Reviews
                    .Where(r => r.MiniatureId == SelectedMiniature.Id)
                    .Include(r => r.User)
                    .Select(r => new ReviewViewModel
                    {
                        UserName = r.User.Username,
                        Rating = r.Rating,
                        Comment = r.Comment,
                        CreatedAt = r.CreatedAt.ToString("dd.MM.yyyy HH:mm"),
                        AvatarUrl = r.User.AvatarUrl
                    })
                    .ToList();

                foreach (var review in reviews)
                {
                    Reviews.Add(review);
                    _ = review.LoadAvatarAsync();
                }
            }
        }

        public void LoadMiniature(MiniatureViewModel miniature)
        {
            using var context = _contextFactory.CreateContext();

            var user = context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
            if (user != null)
            {
                var isFav = context.FavoriteMiniatures
                    .Any(f => f.UserId == user.Id && f.MiniatureId == miniature.Id);
                miniature.IsFavorite = isFav;
            }

            SelectedMiniature = miniature;
        }

        private void ExecuteBackToListCommand(object obj)
        {
            OnNavigateBack?.Invoke(null);
        }

        private void ExecuteView3DModelCommand(object obj)
        {
            if (SelectedMiniature != null && !string.IsNullOrEmpty(SelectedMiniature.ModelUrl))
            {
                if (!Uri.TryCreate(SelectedMiniature.ModelUrl, UriKind.Absolute, out var uri) ||
                    (uri.Scheme != Uri.UriSchemeHttp &&
                     uri.Scheme != Uri.UriSchemeHttps &&
                     uri.Scheme != Uri.UriSchemeFile))
                {
                    ShowErrorMessageBox("Невірний формат шляху до 3D моделі.");
                    return;
                }

                try
                {
                    var modelWindow = new _3DModelView(SelectedMiniature.ModelUrl);
                    modelWindow.ShowDialog();

                    using var context = _contextFactory.CreateContext();
                    LogUserActivity(context, "Перегляд 3D моделі", "3D model view", SelectedMiniature.Name, SelectedMiniature.Name);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"[3D Model Error] {ex}");
                    ShowErrorMessageBox($"Помилка при відкритті 3D моделі:\n{ex.Message}");
                }
            }
            else
            {
                ShowErrorMessageBox(Strings.ModelAnavaible);
            }
        }

        private void LogUserActivity(AppDbContext context, string actionUk, string actionEn, string detailsUk = "", string detailsEn = "")
        {
            var user = context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
            if (user != null)
            {
                var activity = new UserActivity
                {
                    UserId = user.Id,
                    Timestamp = DateTime.UtcNow.AddHours(3)
                };

                context.UserActivities.Add(activity);
                context.SaveChanges();

                var translations = new List<UserActivityTranslation>
                {
                    new()
                    {
                        UserActivityId = activity.Id,
                        LanguageCode = "uk",
                        Action = actionUk,
                        Details = detailsUk
                    },
                    new()
                    {
                        UserActivityId = activity.Id,
                        LanguageCode = "en",
                        Action = actionEn,
                        Details = detailsEn
                    }
                };

                context.UserActivityTranslations.AddRange(translations);
                context.SaveChanges();
            }
        }

        private int? GetUserIdByUsername(AppDbContext context, string username)
        {
            var user = context.Users.FirstOrDefault(u => u.Username == username);
            return user?.Id;
        }

        public class ReviewViewModel : ViewModelBase
        {
            public string UserName { get; set; }
            public int Rating { get; set; }
            public string Comment { get; set; }
            public string CreatedAt { get; set; }

            private string _avatarUrl;
            public string AvatarUrl
            {
                get => _avatarUrl;
                set
                {
                    _avatarUrl = value;
                    OnPropertyChanged(nameof(AvatarUrl));
                }
            }

            private ImageSource _avatarImage;
            public ImageSource AvatarImage
            {
                get => _avatarImage;
                set
                {
                    _avatarImage = value;
                    OnPropertyChanged(nameof(AvatarImage));
                }
            }

            public async Task LoadAvatarAsync()
            {
                string placeholder = "https://minisculptures.blob.core.windows.net/avatars/avatar.png";
                string url = string.IsNullOrWhiteSpace(AvatarUrl) ? placeholder : $"https://minisculptures.blob.core.windows.net/avatars/{AvatarUrl}";

                try
                {
                    string cacheDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MiniatureAvatarCache");
                    Directory.CreateDirectory(cacheDir);
                    string fileName = Path.GetFileName(new Uri(url).LocalPath);
                    string localPath = Path.Combine(cacheDir, fileName);

                    if (!File.Exists(localPath))
                    {
                        using var client = new System.Net.WebClient();
                        await client.DownloadFileTaskAsync(url, localPath);
                    }

                    await Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.UriSource = new Uri(localPath, UriKind.Absolute);
                        bitmap.EndInit();
                        bitmap.Freeze();
                        AvatarImage = bitmap;
                    });
                }
                catch
                {
                }
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
