using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.MVVM.View;
using A_journey_through_miniature_Uzhhorod.MVVM.ViewModel.Admin;
using A_journey_through_miniature_Uzhhorod.Properties;
using A_journey_through_miniature_Uzhhorod.Resources;
using FontAwesome.Sharp;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public bool IsLoggedIn => !string.IsNullOrEmpty(Settings.Default.username);

        private readonly IAppDbContextFactory _contextFactory;

        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public ViewModelBase CurrentChildView
        {
            get => _currentChildView;
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        private readonly HomeViewModel _homeViewModel;
        private readonly EventsViewModel _eventsViewModel;
        private readonly MiniaturesViewModel _miniaturesViewModel;
        private readonly MiniatureDetailsViewModel _miniatureDetailsViewModel;
        private readonly MapeViewModel _mapeViewModel;
        private readonly PersonalOfficeViewModel _personalOfficeViewModel;
        private readonly FeedbackViewModel _feedbackViewModel;
        private readonly QuestViewModel _questViewModel;
        private readonly AchievementViewModel _achievementViewModel;
        private readonly HelpViewModel _helpViewModel;

        //admin
        private readonly AdminHomeViewModel _adminHomeViewModel;
        private readonly EditEventsViewModel _editEventsViewModel;
        private readonly EditFeedbackViewModel _editFeedbackViewModel;
        private readonly EditSculptureViewModel _editSculptureViewModel;
        private readonly EditUsersViewModel _editUsersViewModel;
        private readonly EditHelpViewModel _editHelpViewModel;
        private readonly MiniatureEditDetailsViewModel _miniatureeditDetailsViewModel;

        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowMapeViewCommand { get; }
        public ICommand ShowMiniaturesViewCommand { get; }
        public ICommand ShowHelpViewCommand { get; }
        public ICommand ShowFeedbackViewCommand { get; }
        public ICommand ShowQuestViewCommand { get; }
        public ICommand ShowAchievementViewCommand { get; }
        public ICommand ShowPersonalOfficeViewCommand { get; }
        public ICommand ShowEventsViewCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand DeleteAccountCommand { get; }

        public ICommand ToggleLanguageCommand { get; }

        private string _languageButtonText;
        public string LanguageButtonText
        {
            get => _languageButtonText;
            set
            {
                _languageButtonText = value;
                OnPropertyChanged(nameof(LanguageButtonText));
            }
        }

        //admin
        public ICommand ShowAdminHomeViewCommand { get; }
        public ICommand ShowEditAchievmentViewCommand { get; }
        public ICommand ShowEditEventsCommand { get; }
        public ICommand ShowEditFeedbackViewCommand { get; }
        public ICommand ShowEditQuestViewCommand { get; }
        public ICommand ShowEditSculptureViewCommand { get; }
        public ICommand ShowEditUsersViewCommand { get; }
        public ICommand ShowEditHelpViewCommand { get; }


        public MainViewModel(IAppDbContextFactory contextFactory, EventsViewModel eventsViewModel, HomeViewModel homeViewModel,
            MiniaturesViewModel miniaturesViewModel, MapeViewModel mapeViewModel, PersonalOfficeViewModel personalOfficeViewModel,
            FeedbackViewModel feedbackViewModel, QuestViewModel questViewModel, AchievementViewModel achievementViewModel,
            HelpViewModel helpViewModel, MiniatureDetailsViewModel miniatureDetailsViewModel, AdminHomeViewModel adminHomeViewModel,
            EditEventsViewModel editEventsViewModel, EditFeedbackViewModel editFeedbackViewModel, EditSculptureViewModel editSculptureViewModel,
            EditUsersViewModel editUsersViewModel, EditHelpViewModel editHelpViewModel, MiniatureEditDetailsViewModel miniatureEditDetailsViewModel)
        {
            Resources.Strings.Culture = new CultureInfo(Settings.Default.LanguageCode);

            _contextFactory = contextFactory ?? throw new ArgumentNullException(nameof(contextFactory));

            _homeViewModel = homeViewModel;
            _eventsViewModel = eventsViewModel;
            _miniaturesViewModel = miniaturesViewModel;
            _mapeViewModel = mapeViewModel;
            _personalOfficeViewModel = personalOfficeViewModel;
            _feedbackViewModel = feedbackViewModel;
            _questViewModel = questViewModel;
            _achievementViewModel = achievementViewModel;
            _helpViewModel = helpViewModel;
            _miniatureDetailsViewModel = miniatureDetailsViewModel;

            //admin
            _adminHomeViewModel = adminHomeViewModel;
            _editEventsViewModel = editEventsViewModel;
            _editFeedbackViewModel = editFeedbackViewModel;
            _editSculptureViewModel = editSculptureViewModel;
            _editUsersViewModel = editUsersViewModel;
            _editHelpViewModel = editHelpViewModel;
            _miniatureeditDetailsViewModel = miniatureEditDetailsViewModel;

            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowMapeViewCommand = new ViewModelCommand(ExecuteShowMapeViewCommand);
            ShowMiniaturesViewCommand = new ViewModelCommand(ExecuteShowMiniaturesViewCommand);
            ShowHelpViewCommand = new ViewModelCommand(ExecuteShowHelpViewCommand);
            ShowFeedbackViewCommand = new ViewModelCommand(ExecuteShowFeedbackViewCommand);
            ShowQuestViewCommand = new ViewModelCommand(ExecuteShowQuestViewCommand);
            ShowAchievementViewCommand = new ViewModelCommand(ExecuteShowAchievementViewCommand);
            ShowPersonalOfficeViewCommand = new ViewModelCommand(ExecuteShowPersonalOfficeViewCommand);
            ShowEventsViewCommand = new ViewModelCommand(ExecuteShowEventsViewCommand);
            LogoutCommand = new ViewModelCommand(ExecuteLogoutCommand);
            DeleteAccountCommand = new ViewModelCommand(ExecuteDeleteAccount);

            //admin
            ShowAdminHomeViewCommand = new ViewModelCommand(ExecuteShowAdminHomeViewCommand);
            ShowEditEventsCommand = new ViewModelCommand(ExecuteShowEditEventsViewCommand);
            ShowEditFeedbackViewCommand = new ViewModelCommand(ExecuteShowEditFeedbackViewCommand);
            ShowEditSculptureViewCommand = new ViewModelCommand(ExecuteShowEditSculptureViewCommand);
            ShowEditUsersViewCommand = new ViewModelCommand(ExecuteShowEditUsersViewCommand);
            ShowEditHelpViewCommand = new ViewModelCommand(ExecuteShowEditHelpViewCommand);

            _miniaturesViewModel.OnNavigate += viewModel =>
            {
                CurrentChildView = viewModel ?? _miniaturesViewModel;
            };

            _homeViewModel.OnNavigate += viewModel =>
            {
                CurrentChildView = viewModel ?? _homeViewModel;
            };

            _editSculptureViewModel.OnNavigate += vm =>
            {
                CurrentChildView = vm ?? _editSculptureViewModel;
            };

            ToggleLanguageCommand = new ViewModelCommand(_ => ToggleLanguage());
            LanguageButtonText = LanguageManager.DisplayLanguage;
            LanguageManager.LanguageChanged += () =>
            {
                Resources.Strings.Culture = new CultureInfo(Settings.Default.LanguageCode);
                LanguageButtonText = LanguageManager.DisplayLanguage;
                UpdateCaption();
            };

            LanguageManager.NotifyLanguageChanged();

            using var context = _contextFactory.CreateContext();
            var username = Settings.Default.username;
            var user = context.Users.FirstOrDefault(u => u.Username == username);

            if (user?.Role == UserRole.Admin)
            {
                ExecuteShowAdminHomeViewCommand(null);
            }
            else
            {
                ExecuteShowHomeViewCommand(null);
            }
        }

        private void ToggleLanguage()
        {
            LanguageManager.ToggleLanguage();
            LanguageManager.NotifyLanguageChanged();
        }

        private void UpdateCaption()
        {
            if (CurrentChildView == _homeViewModel)
                Caption = Resources.Strings.RadioButton_Home;
            else if (CurrentChildView == _mapeViewModel)
                Caption = Resources.Strings.RadioButtonMap;
            else if (CurrentChildView == _miniaturesViewModel)
                Caption = Resources.Strings.RadioButtonMiniatures;
            else if (CurrentChildView == _miniatureDetailsViewModel)
                Caption = Resources.Strings.RadioButtonMiniatures;
            else if (CurrentChildView is MiniatureDetailsViewModel)
                Caption = Resources.Strings.RadioButton_Home;
            else if (CurrentChildView == _feedbackViewModel)
                Caption = Resources.Strings.RadioButtonFeedback;
            else if (CurrentChildView == _questViewModel)
                Caption = Resources.Strings.RadioButtonQuest;
            else if (CurrentChildView == _achievementViewModel)
                Caption = Resources.Strings.RadioButtonAchievement;
            else if (CurrentChildView == _personalOfficeViewModel)
                Caption = Resources.Strings.RadioButtonPersonalOffice;
            else if (CurrentChildView == _eventsViewModel)
                Caption = Resources.Strings.RadioButtonEvents;
            else if (CurrentChildView == _helpViewModel)
                Caption = Resources.Strings.RadioButtonHelp;
            else if (CurrentChildView == _editEventsViewModel)
                Caption = Resources.Strings.RadioButtonEditEvents;
            else if (CurrentChildView == _editFeedbackViewModel)
                Caption = Resources.Strings.RadioButtonFeedback;
            else if (CurrentChildView == _editSculptureViewModel)
                Caption = Resources.Strings.RadioButtonEditSculpture;
            else if (CurrentChildView == _miniatureeditDetailsViewModel)
                Caption = Resources.Strings.RadioButtonEditSculpture;
            else if (CurrentChildView == _editUsersViewModel)
                Caption = Resources.Strings.RadioButtonEditUsers;
            else if (CurrentChildView == _editHelpViewModel)
                Caption = Resources.Strings.RadioButtonEditHelp;
            else if (CurrentChildView == _adminHomeViewModel)
                Caption = Resources.Strings.RadioButton_Home;
        }

        private void ExecuteDeleteAccount(object obj)
        {
            MessageBoxView messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = Strings.AccountDelete;
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
                _personalOfficeViewModel.DeleteAccount();
                _personalOfficeViewModel.Logout();
                OnPropertyChanged(nameof(IsLoggedIn));
                if (_personalOfficeViewModel.deleteVerCode == true)
                {
                    ExecuteShowHomeViewCommand(null);
                }
                MessageBoxView.buttonYesClicked = false;
            }
        }

        private void ExecuteLogoutCommand(object obj)
        {
            MessageBoxView messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = Strings.QuestionLogOut;
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
                _personalOfficeViewModel.LogUserActivity("Вихід з аккаунту", "Logged out");
                _personalOfficeViewModel.Logout();
                ExecuteShowHomeViewCommand(null);
                MessageBoxView.buttonYesClicked = false;
                OnPropertyChanged(nameof(IsLoggedIn));
            }
        }

        private void ExecuteShowEventsViewCommand(object obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Події", "Events");
            CurrentChildView = _eventsViewModel;
            Caption = Resources.Strings.RadioButtonEvents;
            Icon = IconChar.Calendar;
        }

        private void ExecuteShowPersonalOfficeViewCommand(object obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Особистий кабінет", "Personal office");
            _personalOfficeViewModel.LoadUserData();
            _personalOfficeViewModel.LoadUserActivities();
            _personalOfficeViewModel.LoadUserFeedbacks();
            CurrentChildView = _personalOfficeViewModel;
            Caption = Resources.Strings.RadioButtonPersonalOffice;
            Icon = IconChar.HomeUser;
        }

        private void ExecuteShowAchievementViewCommand(object obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Досягнення", "Achievements");
            _achievementViewModel.LoadAchievements();
            CurrentChildView = _achievementViewModel;
            Caption = Resources.Strings.RadioButtonAchievement;
            Icon = IconChar.Trophy;
        }

        private void ExecuteShowQuestViewCommand(object obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Квести", "Quests");
            CurrentChildView = _questViewModel;
            Caption = Resources.Strings.RadioButtonQuest;
            Icon = IconChar.ClipboardQuestion;
        }

        private void ExecuteShowFeedbackViewCommand(object obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Зворотній зв'язок", "Feedback");
            CurrentChildView = _feedbackViewModel;
            Caption = Resources.Strings.RadioButtonFeedback;
            Icon = IconChar.Message;
        }

        private void ExecuteShowHelpViewCommand(object obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Допомога в користуванні", "Help");
            _helpViewModel.LoadHelpText();
            CurrentChildView = _helpViewModel;
            Caption = Resources.Strings.RadioButtonHelp;
            Icon = IconChar.HandsHelping;
        }

        private void ExecuteShowMiniaturesViewCommand(object obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Список скульптурок", "Miniature list");
            CurrentChildView = _miniaturesViewModel;
            Caption = Resources.Strings.RadioButtonMiniatures;
            Icon = IconChar.ListAlt;
        }

        private void ExecuteShowMapeViewCommand(object obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Мапа розташування", "Map view");
            _mapeViewModel.LoadMarkers();
            CurrentChildView = _mapeViewModel;
            Caption = Resources.Strings.RadioButtonMap;
            Icon = IconChar.Map;
        }

        private void ExecuteShowHomeViewCommand(object? obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Головна", "Home");
            _homeViewModel.LoadData();
            CurrentChildView = _homeViewModel;
            Caption = Resources.Strings.RadioButton_Home;
            Icon = IconChar.Home;
        }

        //admin
        private void ExecuteShowEditHelpViewCommand(object obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Редагування допомоги", "Editing help");
            CurrentChildView = _editHelpViewModel;
            Caption = Resources.Strings.RadioButtonEditHelp;
            Icon = IconChar.HandsHelping;
        }

        private void ExecuteShowEditUsersViewCommand(object obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Користувачі", "Users");
            _editUsersViewModel.LoadUsers();
            CurrentChildView = _editUsersViewModel;
            Caption = Resources.Strings.RadioButtonEditUsers;
            Icon = IconChar.UserEdit;
        }

        private void ExecuteShowEditSculptureViewCommand(object obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Редагування скульптур", "Editing sculptures");
            CurrentChildView = _editSculptureViewModel;
            Caption = Resources.Strings.RadioButtonEditSculpture;
            Icon = IconChar.ListAlt;
        }

        private void ExecuteShowEditFeedbackViewCommand(object obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Зворотній зв'язок", "Feedback");
            CurrentChildView = _editFeedbackViewModel;
            Caption = Resources.Strings.RadioButtonFeedback;
            Icon = IconChar.Message;
        }

        private void ExecuteShowEditEventsViewCommand(object obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Редагування подій", "Editing events");
            CurrentChildView = _editEventsViewModel;
            Caption = Resources.Strings.RadioButtonEditEvents;
            Icon = IconChar.Calendar;
        }

        private void ExecuteShowAdminHomeViewCommand(object? obj)
        {
            _personalOfficeViewModel.LogUserActivity("Перегляд вкладки", "Viewed tab", "Головна", "Home");
            _adminHomeViewModel.RefreshData();
            CurrentChildView = _adminHomeViewModel;
            Caption = Resources.Strings.RadioButton_Home;
            Icon = IconChar.Home;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}