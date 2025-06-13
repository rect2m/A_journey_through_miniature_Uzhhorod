using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using static A_journey_through_miniature_Uzhhorod.MVVM.ViewModel.MiniaturesViewModel;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;
        private readonly QuestService _questService;
        private readonly MiniatureDetailsViewModel _detailsViewModel;
        private readonly Random _random = new();

        public ObservableCollection<MiniatureViewModel> TopRatedMiniatures { get; set; } = new();

        private EventViewModel _randomEvent;
        public EventViewModel RandomEvent
        {
            get => _randomEvent;
            set { _randomEvent = value; OnPropertyChanged(nameof(RandomEvent)); }
        }

        public event Action<ViewModelBase> OnNavigate;

        public HomeViewModel(IAppDbContextFactory contextFactory, QuestService questService)
        {
            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));
            _questService = questService ?? throw new ArgumentNullException(nameof(questService));
            _detailsViewModel = new MiniatureDetailsViewModel(_contextFactory, _questService);
            _detailsViewModel.OnNavigateBack += _ => OnNavigate?.Invoke(this);
            LanguageManager.LanguageChanged += OnLanguageChanged;

            LoadData();
        }

        private void OnLanguageChanged() => LoadData();

        public void LoadData()
        {
            LoadTopMiniatures();
            LoadRandomEvent();
        }

        private async void LoadTopMiniatures()
        {
            using var context = _contextFactory.CreateContext();

            var miniatures = context.Miniatures
                .Include(m => m.Translations)
                .Include(m => m.Reviews)
                .AsNoTracking()
                .ToList();

            var rated = miniatures
    .Where(m => m.Reviews.Any())
    .OrderByDescending(m => m.Reviews.Average(r => r.Rating))
    .ToList();

            var topMiniatures = new List<Miniature>();
            topMiniatures.AddRange(rated.Take(3));

            if (topMiniatures.Count < 3)
            {
                var topIds = topMiniatures.Select(m => m.Id).ToHashSet();

                var unrated = miniatures
                    .Where(m => !topIds.Contains(m.Id))
                    .OrderBy(_ => _random.Next())
                    .Take(3 - topMiniatures.Count);

                topMiniatures.AddRange(unrated);
            }

            TopRatedMiniatures.Clear();

            foreach (var miniature in topMiniatures)
            {
                var translation = miniature.Translations.FirstOrDefault(t => t.LanguageCode == LanguageManager.CurrentLanguage);
                if (translation != null)
                {
                    var vm = new MiniatureViewModel
                    {
                        Id = miniature.Id,
                        Name = translation.Name,
                        Description = translation.Description,
                        AverageRating = miniature.Reviews.Any() ? miniature.Reviews.Average(r => r.Rating) : 0,
                        ImageUrl = miniature.ImageUrl,
                        ImagePath = miniature.ImageUrl, // Встановлюємо URL як ImagePath
                        Latitude = miniature.Latitude,
                        Longitude = miniature.Longitude,
                        ModelUrl = miniature.ModelUrl
                    };

                    TopRatedMiniatures.Add(vm); // додати одразу
                    _ = Task.Run(() => vm.LoadImageAsync()); // асинхронно завантажити зображення
                }
            }
        }

        public void LoadRandomEvent()
        {
            using var context = _contextFactory.CreateContext();

            var events = context.Events
                .Include(e => e.Translations)
                .AsNoTracking()
                .ToList();

            if (events.Any())
            {
                var selectedEvent = events[_random.Next(events.Count)];
                var translation = selectedEvent.Translations.FirstOrDefault(t => t.LanguageCode == LanguageManager.CurrentLanguage);

                if (translation != null)
                {
                    RandomEvent = new EventViewModel
                    {
                        Title = translation.Title,
                        Description = translation.Description,
                        EventDate = selectedEvent.EventDate
                    };
                }
            }
        }

        public void NavigateToMiniature(MiniatureViewModel miniature)
        {
            _detailsViewModel.LoadMiniature(miniature);
            _detailsViewModel.SelectedMiniature = miniature;
            OnNavigate?.Invoke(_detailsViewModel);
        }

        public class EventViewModel
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime EventDate { get; set; }
        }
    }
}
