using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.Resources;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel.Admin
{
    public class FeedbackEntry : ViewModelBase
    {
        public string Username { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Timestamp { get; set; }

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

        public async Task LoadAvatarAsync(string avatarFileName)
        {
            string placeholder = "https://minisculptures.blob.core.windows.net/avatars/avatar.png";
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
    }

    public class InfoCard
    {
        public string Title { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string LastUpdated { get; set; }
    }

    public class AdminHomeViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;

        public ObservableCollection<InfoCard> InfoCards { get; set; } = new();
        public ObservableCollection<FeedbackEntry> FeedbackEntries { get; set; } = new();

        public ISeries[] PieSeries { get; set; }
        public ISeries[] ColumnSeries { get; set; }
        public Axis[] ColumnXAxis { get; set; }
        public Axis[] ColumnYAxis { get; set; }

        public bool IsFeedbackEmpty => FeedbackEntries == null || FeedbackEntries.Count == 0;

        public AdminHomeViewModel(IAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            LanguageManager.LanguageChanged += RefreshData;
            RefreshData();
        }

        public void RefreshData()
        {
            InfoCards.Clear();
            FeedbackEntries.Clear();
            LoadInfoCards();
            LoadPieChart();
            _ = LoadFeedback();
        }

        private async Task LoadFeedback()
        {
            using var context = _contextFactory.CreateContext();

            var messages = context.Feedbacks
                .Include(f => f.User)
                .OrderByDescending(f => f.SentAt)
                .Take(5)
                .ToList();

            foreach (var f in messages)
            {
                var username = string.IsNullOrWhiteSpace(f.User?.Username) ? "Анонім" : f.User.Username;
                var timestamp = f.SentAt.ToString("dd.MM.yyyy HH:mm");

                bool alreadyExists = FeedbackEntries.Any(e =>
                    e.Username == username &&
                    e.Title == f.Email &&
                    e.Message == f.Message &&
                    e.Timestamp == timestamp);

                if (alreadyExists)
                    continue;

                var entry = new FeedbackEntry
                {
                    Username = username,
                    Title = f.Email,
                    Message = f.Message,
                    Timestamp = timestamp
                };

                FeedbackEntries.Add(entry);
                await entry.LoadAvatarAsync(f.User?.AvatarUrl);
            }

            OnPropertyChanged(nameof(IsFeedbackEmpty));
        }


        private void LoadInfoCards()
        {
            using var context = _contextFactory.CreateContext();

            var userCount = context.Users.Count();
            InfoCards.Add(new InfoCard
            {
                Title = Strings.Users,
                Value = userCount.ToString(),
                Icon = "Users",
            });

            var reviewCount = context.Reviews.Count();
            InfoCards.Add(new InfoCard
            {
                Title = Strings.Reviews,
                Value = reviewCount.ToString(),
                Icon = "CommentDots",
            });

            var activityCount = context.UserActivities.Count();
            InfoCards.Add(new InfoCard
            {
                Title = Strings.Activities,
                Value = activityCount.ToString(),
                Icon = "Bolt",
            });

            var miniatureCount = context.Miniatures.Count();
            InfoCards.Add(new InfoCard
            {
                Title = Strings.Miniatures,
                Value = miniatureCount.ToString(),
                Icon = "Landmark",
            });
        }

        private void LoadPieChart()
        {
            using var context = _contextFactory.CreateContext();

            var active = context.Users.Count(u => u.Status == UserStatus.Active);
            var blocked = context.Users.Count(u => u.Status == UserStatus.Blocked);

            PieSeries = new ISeries[]
            {
                new PieSeries<int>
                {
                    Values = new[] { active },
                    Name = Strings.Active,
                    Fill = new SolidColorPaint(SKColors.MediumSeaGreen),
                },
                new PieSeries<int>
                {
                    Values = new[] { blocked },
                    Name = Strings.Blocked,
                    Fill = new SolidColorPaint(SKColors.IndianRed),
                }
            };
        }
    }
}
