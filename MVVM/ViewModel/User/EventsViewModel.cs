using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Properties;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    public class EventsViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;
        private string CurrentLanguage => LanguageManager.CurrentLanguage;
        private string _searchQuery = "";
        private bool _isAscending = true;
        private int _currentPage = 1;
        private const int PageSize = 6;

        public ObservableCollection<EventViewModel> Events { get; set; } = new();
        private List<EventViewModel> _allEvents = new();
        private List<EventViewModel> _filteredEvents = new();

        public string SortIcon
        {
            get
            {
                var lang = Settings.Default.LanguageCode;
                return lang == "uk"
                    ? (_isAscending ? "⬆ Старіші → Новіші" : "⬇ Новіші → Старіші")
                    : (_isAscending ? "⬆ Older → Newer" : "⬇ Newer → Older");
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    ApplyFilterAndPagination();
                }
            }
        }

        public bool IsAscending
        {
            get => _isAscending;
            set
            {
                if (_isAscending != value)
                {
                    _isAscending = value;
                    OnPropertyChanged(nameof(IsAscending));
                    OnPropertyChanged(nameof(SortIcon));
                    ApplyFilterAndPagination();
                }
            }
        }

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged(nameof(CurrentPage));
                    LoadPagedEvents();
                }
            }
        }

        public int TotalPages => (int)Math.Ceiling((double)_filteredEvents.Count / PageSize);

        public ICommand ToggleSortingCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand PrevPageCommand { get; }

        public EventsViewModel(IAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            ToggleSortingCommand = new RelayCommand(_ => ToggleSorting());
            NextPageCommand = new RelayCommand(_ => { if (CurrentPage < TotalPages) CurrentPage++; });
            PrevPageCommand = new RelayCommand(_ => { if (CurrentPage > 1) CurrentPage--; });

            LoadEvents();

            LanguageManager.LanguageChanged += () =>
            {
                LoadEvents();
                OnPropertyChanged(nameof(SortIcon));
            };
        }

        private void ToggleSorting()
        {
            IsAscending = !IsAscending;
        }

        private void LoadEvents()
        {
            using var context = _contextFactory.CreateContext();

            Events.Clear();
            _allEvents.Clear();

            var events = context.Events
                .Include(e => e.Translations)
                .AsNoTracking()
                .ToList();

            foreach (var evt in events)
            {
                var translation = evt.Translations.FirstOrDefault(t => t.LanguageCode == CurrentLanguage);
                if (translation != null)
                {
                    var eventVm = new EventViewModel
                    {
                        Title = translation.Title,
                        Description = translation.Description,
                        EventDate = evt.EventDate
                    };

                    _allEvents.Add(eventVm);
                }
            }

            ApplyFilterAndPagination();
        }

        private void ApplyFilterAndPagination()
        {
            var filtered = _allEvents.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(_searchQuery))
            {
                filtered = filtered.Where(e =>
                    e.Title.Contains(_searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    e.EventDate.ToString("dd.MM.yyyy").Contains(_searchQuery)
                );
            }

            filtered = IsAscending
                ? filtered.OrderBy(e => e.EventDate)
                : filtered.OrderByDescending(e => e.EventDate);

            _filteredEvents = filtered.ToList();
            CurrentPage = 1;
            LoadPagedEvents();
            OnPropertyChanged(nameof(TotalPages));
        }

        private void LoadPagedEvents()
        {
            Events.Clear();
            foreach (var evt in _filteredEvents.Skip((CurrentPage - 1) * PageSize).Take(PageSize))
            {
                Events.Add(evt);
            }
        }

        public class EventViewModel
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime EventDate { get; set; }
        }
    }
}
