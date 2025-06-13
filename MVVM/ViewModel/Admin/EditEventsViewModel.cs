using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models.Translation;
using A_journey_through_miniature_Uzhhorod.MVVM.View;
using A_journey_through_miniature_Uzhhorod.Resources;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel.Admin
{
    public class EditEventsViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;
        private string _searchQuery = "";
        private bool _isAscending = true;
        private int _currentPage = 1;
        private const int PageSize = 6;

        public ObservableCollection<EditableEventViewModel> Events { get; } = new();
        private List<EditableEventViewModel> _allEvents = new();
        private List<EditableEventViewModel> _filteredEvents = new();

        private EditableEventViewModel? _selectedEvent;
        public EditableEventViewModel? SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                SelectedLanguage = LanguageManager.CurrentLanguage;
                UpdateTranslationViewModel();
                OnPropertyChanged(nameof(SelectedEvent));
                OnPropertyChanged(nameof(IsPanelOpen));
                OnPropertyChanged(nameof(CanDeleteSelectedEvent));
            }
        }

        private string _selectedLanguage = LanguageManager.CurrentLanguage;
        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set
            {
                _selectedLanguage = value;
                UpdateTranslationViewModel();
                OnPropertyChanged(nameof(SelectedLanguage));
            }
        }

        private TranslationViewModel? _selectedTranslation;
        public TranslationViewModel? SelectedTranslation
        {
            get => _selectedTranslation;
            private set
            {
                _selectedTranslation = value;
                OnPropertyChanged(nameof(SelectedTranslation));
            }
        }

        public bool IsPanelOpen => SelectedEvent != null;

        public bool CanDeleteSelectedEvent => SelectedEvent != null && SelectedEvent.Id != 0;

        public ICommand ToggleSortingCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand PrevPageCommand { get; }
        public ICommand OpenAddDetailsViewCommand { get; }
        public ICommand SaveCurrentEventCommand { get; }
        public ICommand DeleteEventCommand { get; }
        public ICommand DeselectEventCommand { get; }
        public ICommand SelectEventCommand { get; }

        public EditEventsViewModel(IAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;

            NextPageCommand = new RelayCommand(_ => { if (CurrentPage < TotalPages) CurrentPage++; });
            PrevPageCommand = new RelayCommand(_ => { if (CurrentPage > 1) CurrentPage--; });
            OpenAddDetailsViewCommand = new RelayCommand(_ => AddNewEvent());
            SaveCurrentEventCommand = new RelayCommand(async _ => await SaveCurrentEventAsync());
            DeleteEventCommand = new RelayCommand(async obj => await DeleteEventAsync(obj));
            DeselectEventCommand = new RelayCommand(_ => { SelectedEvent = null; });
            SelectEventCommand = new RelayCommand(obj => { if (obj is EditableEventViewModel ev) SelectedEvent = ev; });

            LoadEvents();

            LanguageManager.LanguageChanged += () =>
            {
                OnPropertyChanged(nameof(SelectedLanguage));
                UpdateTranslationViewModel();
                LoadPagedEvents();
            };
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

        private void AddNewEvent()
        {
            SelectedEvent = new EditableEventViewModel();
        }

        private async Task DeleteEventAsync(object? obj)
        {
            if (obj is not EditableEventViewModel ev) return;

            var confirm = new MessageBoxView();
            confirm.TextBlockProblem1.Text = Strings.EventDelete;
            confirm.ButtonYes.Content = Strings.Yes;
            confirm.ButtonOk.Content = Strings.No;
            confirm.ButtonYes.Visibility = System.Windows.Visibility.Visible;
            confirm.ButtonOk.Visibility = System.Windows.Visibility.Visible;
            confirm.ButtonNo.Visibility = System.Windows.Visibility.Hidden;
            confirm.IconSuccess.Visibility = System.Windows.Visibility.Hidden;
            confirm.IconThink.Visibility = System.Windows.Visibility.Visible;
            confirm.IconError.Visibility = System.Windows.Visibility.Hidden;
            confirm.ShowDialog();

            if (MessageBoxView.buttonYesClicked != true)
                return;

            using var context = _contextFactory.CreateContext();
            var entity = await context.Events.Include(e => e.Translations)
                .FirstOrDefaultAsync(e => e.Id == ev.Id);

            if (entity != null)
            {
                context.Events.Remove(entity);
                await context.SaveChangesAsync();
            }

            _allEvents.Remove(ev);
            Events.Remove(ev);
            if (SelectedEvent == ev)
                SelectedEvent = null;

            ApplyFilterAndPagination();

            MessageBoxView.buttonYesClicked = false;
        }

        private void LoadEvents()
        {
            using var context = _contextFactory.CreateContext();

            Events.Clear();
            _allEvents.Clear();

            var events = context.Events.Include(e => e.Translations).AsNoTracking().ToList();

            foreach (var ev in events)
            {
                var uk = ev.Translations.FirstOrDefault(t => t.LanguageCode == "uk");
                var en = ev.Translations.FirstOrDefault(t => t.LanguageCode == "en");

                _allEvents.Add(new EditableEventViewModel
                {
                    Id = ev.Id,
                    EventDate = ev.EventDate,
                    TitleUk = uk?.Title ?? "",
                    DescriptionUk = uk?.Description ?? "",
                    TitleEn = en?.Title ?? "",
                    DescriptionEn = en?.Description ?? ""
                });
            }

            ApplyFilterAndPagination();
        }

        private void ApplyFilterAndPagination()
        {
            var filtered = _allEvents.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(_searchQuery))
            {
                filtered = filtered.Where(e =>
                    e.TitleUk.Contains(_searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    e.TitleEn.Contains(_searchQuery, StringComparison.OrdinalIgnoreCase) ||
                    e.EventDate.ToString("dd.MM.yyyy").Contains(_searchQuery));
            }

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

        private async Task SaveCurrentEventAsync()
        {
            if (SelectedEvent == null) return;

            if (string.IsNullOrWhiteSpace(SelectedEvent.TitleUk) ||
                string.IsNullOrWhiteSpace(SelectedEvent.DescriptionUk) ||
                string.IsNullOrWhiteSpace(SelectedEvent.TitleEn) ||
                string.IsNullOrWhiteSpace(SelectedEvent.DescriptionEn))
            {
                ShowErrorMessageBox(Strings.EventsValidation);
                return;
            }

            if (SelectedEvent.EventDate == default)
            {
                ShowErrorMessageBox(Strings.EventsDate);
                return;
            }

            if (SelectedEvent.EventDate.Kind == DateTimeKind.Unspecified)
                SelectedEvent.EventDate = DateTime.SpecifyKind(SelectedEvent.EventDate, DateTimeKind.Utc);

            using var context = _contextFactory.CreateContext();

            var entity = await context.Events
                .Include(e => e.Translations)
                .FirstOrDefaultAsync(e => e.Id == SelectedEvent.Id);

            if (entity == null)
            {
                entity = new Database.Models.Event
                {
                    EventDate = SelectedEvent.EventDate,
                    Translations = new List<EventTranslation>
                    {
                        new() { LanguageCode = "uk", Title = SelectedEvent.TitleUk, Description = SelectedEvent.DescriptionUk },
                        new() { LanguageCode = "en", Title = SelectedEvent.TitleEn, Description = SelectedEvent.DescriptionEn }
                    }
                };

                context.Events.Add(entity);
                await context.SaveChangesAsync();

                SelectedEvent.Id = entity.Id;
                _allEvents.Add(SelectedEvent);
            }
            else
            {
                entity.EventDate = SelectedEvent.EventDate;

                var uk = entity.Translations.FirstOrDefault(t => t.LanguageCode == "uk");
                if (uk != null)
                {
                    uk.Title = SelectedEvent.TitleUk;
                    uk.Description = SelectedEvent.DescriptionUk;
                }

                var en = entity.Translations.FirstOrDefault(t => t.LanguageCode == "en");
                if (en != null)
                {
                    en.Title = SelectedEvent.TitleEn;
                    en.Description = SelectedEvent.DescriptionEn;
                }
            }

            await context.SaveChangesAsync();
            ShowSuccessMessageBox(Strings.EventSave);
            SelectedEvent = null;
            ApplyFilterAndPagination();
        }

        private void ShowSuccessMessageBox(string text)
        {
            var box = new MessageBoxView();
            box.TextBlockProblem1.Text = text;
            box.ButtonYes.Visibility = System.Windows.Visibility.Hidden;
            box.ButtonNo.Visibility = System.Windows.Visibility.Hidden;
            box.IconError.Visibility = System.Windows.Visibility.Hidden;
            box.IconThink.Visibility = System.Windows.Visibility.Hidden;
            box.ShowDialog();
        }

        private void ShowErrorMessageBox(string text)
        {
            var box = new MessageBoxView();
            box.TextBlockProblem1.Text = text;
            box.ButtonYes.Visibility = System.Windows.Visibility.Hidden;
            box.ButtonNo.Visibility = System.Windows.Visibility.Hidden;
            box.IconSuccess.Visibility = System.Windows.Visibility.Hidden;
            box.IconThink.Visibility = System.Windows.Visibility.Hidden;
            box.ShowDialog();
        }

        private void UpdateTranslationViewModel()
        {
            if (_selectedEvent == null)
            {
                SelectedTranslation = null;
                return;
            }

            SelectedTranslation = SelectedLanguage switch
            {
                "uk" => new TranslationViewModel
                {
                    Title = _selectedEvent.TitleUk,
                    Description = _selectedEvent.DescriptionUk,
                    Apply = (title, desc) =>
                    {
                        _selectedEvent.TitleUk = title;
                        _selectedEvent.DescriptionUk = desc;
                    }
                },
                "en" => new TranslationViewModel
                {
                    Title = _selectedEvent.TitleEn,
                    Description = _selectedEvent.DescriptionEn,
                    Apply = (title, desc) =>
                    {
                        _selectedEvent.TitleEn = title;
                        _selectedEvent.DescriptionEn = desc;
                    }
                },
                _ => null
            };
        }

    }

    public class EditableEventViewModel : ViewModelBase
    {
        public DateTime EventDate { get; set; } = DateTime.UtcNow;
        public string TitleUk { get; set; } = string.Empty;
        public string DescriptionUk { get; set; } = string.Empty;
        public string TitleEn { get; set; } = string.Empty;
        public string DescriptionEn { get; set; } = string.Empty;
        public int Id { get; set; }

        public string Title => LanguageManager.CurrentLanguage == "uk" ? TitleUk : TitleEn;
        public string Description => LanguageManager.CurrentLanguage == "uk" ? DescriptionUk : DescriptionEn;
    }

    public class TranslationViewModel : ViewModelBase
    {
        private string _title = string.Empty;
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    Apply?.Invoke(_title, Description);
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        private string _description = string.Empty;
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    Apply?.Invoke(Title, _description);
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public Action<string, string>? Apply { get; set; }
    }
}
