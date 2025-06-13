using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Properties;
using FontAwesome.Sharp;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    public class AchievementDisplayModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IconChar Icon { get; set; }
        public bool IsUnlocked { get; set; }
    }

    public class AchievementViewModel : ViewModelBase
    {
        private const int PageSize = 10;
        private int _currentPage = 1;
        private string _selectedFilter;

        private List<AchievementDisplayModel> _allAchievements = new();
        private List<AchievementDisplayModel> _filteredAchievements = new();

        public ObservableCollection<string> FilterOptions { get; set; } = new();
        public ObservableCollection<AchievementDisplayModel> PagedAchievements { get; set; } = new();

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
                LoadPagedAchievements();
            }
        }

        public int TotalPages => (int)Math.Ceiling((double)_filteredAchievements.Count / PageSize);

        public string SelectedFilter
        {
            get => _selectedFilter;
            set
            {
                if (_selectedFilter != value)
                {
                    _selectedFilter = value;
                    OnPropertyChanged(nameof(SelectedFilter));
                    ApplyFilter();
                }
            }
        }

        private readonly IAppDbContextFactory _contextFactory;

        public AchievementViewModel(IAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;

            LanguageManager.LanguageChanged += () =>
            {
                UpdateFilterOptions();
                LoadAchievements();
            };

            UpdateFilterOptions();
            LoadAchievements();
        }

        private void UpdateFilterOptions()
        {
            FilterOptions.Clear();
            FilterOptions.Add(Resources.Strings.Filter_All);
            FilterOptions.Add(Resources.Strings.Filter_Completed);
            FilterOptions.Add(Resources.Strings.Filter_Incomplete);

            if (string.IsNullOrEmpty(SelectedFilter) || !FilterOptions.Contains(SelectedFilter))
            {
                SelectedFilter = FilterOptions.FirstOrDefault();
            }
        }

        public void LoadAchievements()
        {
            using var context = _contextFactory.CreateContext();

            var user = context.Users.FirstOrDefault(u => u.Username == Settings.Default.username);
            if (user == null) return;

            var userAchievements = context.UserAchievements
                .Where(ua => ua.UserId == user.Id)
                .Select(ua => ua.AchievementId)
                .ToHashSet();

            var allAchievements = context.Achievements
                .Include(a => a.Translations)
                .ToList();

            _allAchievements = allAchievements.Select(achievement =>
            {
                var translation = achievement.Translations.FirstOrDefault(t => t.LanguageCode == LanguageManager.CurrentLanguage) ??
                                  achievement.Translations.FirstOrDefault();

                var isUnlocked = userAchievements.Contains(achievement.Id);

                if (!Enum.TryParse<IconChar>(achievement.IconName, out var iconChar))
                {
                    iconChar = IconChar.Trophy;
                }

                return new AchievementDisplayModel
                {
                    Title = translation?.Title ?? "Невідомо",
                    Description = translation?.Description ?? string.Empty,
                    Icon = iconChar,
                    IsUnlocked = isUnlocked
                };
            }).ToList();

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            _filteredAchievements = SelectedFilter switch
            {
                var x when x == Resources.Strings.Filter_Completed => _allAchievements.Where(a => a.IsUnlocked).ToList(),
                var x when x == Resources.Strings.Filter_Incomplete => _allAchievements.Where(a => !a.IsUnlocked).ToList(),
                _ => _allAchievements
            };

            CurrentPage = 1;
            LoadPagedAchievements();
            OnPropertyChanged(nameof(TotalPages));
        }

        private void LoadPagedAchievements()
        {
            PagedAchievements.Clear();
            foreach (var a in _filteredAchievements.Skip((CurrentPage - 1) * PageSize).Take(PageSize))
                PagedAchievements.Add(a);
        }

        public ICommand NextPageCommand => new ViewModelCommand(_ =>
        {
            if (CurrentPage < TotalPages) CurrentPage++;
        });

        public ICommand PrevPageCommand => new ViewModelCommand(_ =>
        {
            if (CurrentPage > 1) CurrentPage--;
        });
    }
}
