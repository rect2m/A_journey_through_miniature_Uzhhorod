using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel.Admin
{
    public class FeedbackItemViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;

        public Feedback Feedback { get; }

        private string _adminReplyText;
        public string AdminReplyText
        {
            get => _adminReplyText;
            set
            {
                if (_adminReplyText != value)
                {
                    _adminReplyText = value;
                    OnPropertyChanged(nameof(AdminReplyText));
                }
            }
        }

        public string UserName => Feedback.User?.Username ?? "Анонім";

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

        public string Category => Feedback.Category?.Trim().ToLower();

        public Brush CategoryBrush => GetCategoryBrush();

        private Brush GetCategoryBrush()
        {
            return Category switch
            {
                "помилка" => Brushes.Red,
                "пропозиція" => Brushes.Green,
                "інше" => Brushes.White,
                _ => Brushes.White
            };
        }

        public ICommand SendReplyCommand { get; }

        public FeedbackItemViewModel(Feedback feedback, IAppDbContextFactory contextFactory)
        {
            Feedback = feedback;
            _contextFactory = contextFactory;
            _adminReplyText = feedback.AdminResponse;
            SendReplyCommand = new RelayCommand(SendReply, _ => !string.IsNullOrWhiteSpace(AdminReplyText));

            _ = LoadAvatarAsync();
        }

        private async Task LoadAvatarAsync()
        {
            string placeholder = "https://minisculptures.blob.core.windows.net/avatars/avatar.png";
            string avatarFileName = Feedback.User?.AvatarUrl;
            string url = string.IsNullOrWhiteSpace(avatarFileName) ? placeholder : $"https://minisculptures.blob.core.windows.net/avatars/{avatarFileName}";

            try
            {
                string cacheDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MiniatureAvatarCache");
                Directory.CreateDirectory(cacheDir);
                string fileName = Path.GetFileName(new Uri(url).LocalPath);
                string localPath = Path.Combine(cacheDir, fileName);

                if (!File.Exists(localPath))
                {
                    using var client = new HttpClient();
                    var data = await client.GetByteArrayAsync(url);
                    await File.WriteAllBytesAsync(localPath, data);
                }

                await System.Windows.Application.Current.Dispatcher.InvokeAsync(() =>
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

        private void SendReply(object _)
        {
            using var context = _contextFactory.CreateContext();
            var entry = context.Feedbacks.FirstOrDefault(f => f.Id == Feedback.Id);
            if (entry != null)
            {
                entry.AdminResponse = AdminReplyText;
                entry.RespondedAt = DateTime.UtcNow;
                context.SaveChanges();

                Feedback.AdminResponse = AdminReplyText;
                OnPropertyChanged(nameof(Feedback));
                OnPropertyChanged(nameof(CategoryBrush));
            }
        }
    }


    public class EditFeedbackViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;
        public ObservableCollection<FeedbackItemViewModel> Feedbacks { get; set; } = new();

        public EditFeedbackViewModel(IAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            LoadFeedbacks();
        }

        private void LoadFeedbacks()
        {
            Feedbacks.Clear();

            using var context = _contextFactory.CreateContext();
            var feedbacks = context.Feedbacks
                .Include(f => f.User)
                .OrderByDescending(f => f.SentAt)
                .ToList();

            foreach (var f in feedbacks)
            {
                Feedbacks.Add(new FeedbackItemViewModel(f, _contextFactory));
            }
        }
    }

}