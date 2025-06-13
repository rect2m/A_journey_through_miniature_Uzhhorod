using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models;
using A_journey_through_miniature_Uzhhorod.MVVM.View;
using A_journey_through_miniature_Uzhhorod.Properties;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel.Admin
{
    public class EditUsersViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;
        private const int PageSize = 12;
        private int _currentPage = 1;
        private List<User> _allUsers = new();
        private List<User> _filteredUsers = new();

        public ObservableCollection<UserViewModel> Users { get; set; } = new();
        public ObservableCollection<string> UserFilters { get; set; } = new();

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
                    ApplyFilter();
                }
            }
        }

        private string _searchQuery;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (_searchQuery != value)
                {
                    _searchQuery = value;
                    OnPropertyChanged(nameof(SearchQuery));
                    ApplyFilter();
                }
            }
        }

        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
                LoadPagedUsers();
            }
        }

        public int TotalPages => Math.Max(1, (int)Math.Ceiling((double)_filteredUsers.Count / PageSize));

        public ICommand NextPageCommand => new RelayCommand(_ =>
        {
            if (CurrentPage < TotalPages)
                CurrentPage++;
        });

        public ICommand PrevPageCommand => new RelayCommand(_ =>
        {
            if (CurrentPage > 1)
                CurrentPage--;
        });

        public ICommand ChangeRoleCommand { get; }
        public ICommand ToggleBlockCommand { get; }
        public ICommand DeleteUserCommand { get; }

        public EditUsersViewModel(IAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;

            ChangeRoleCommand = new RelayCommand(ChangeRole);
            ToggleBlockCommand = new RelayCommand(ToggleBlock);
            DeleteUserCommand = new RelayCommand(DeleteUser);

            LoadFilters();
            LoadUsers();
        }

        private void LoadFilters()
        {
            string lang = LanguageManager.CurrentLanguage;
            string all = lang == "uk" ? "Всі" : "All";
            string admins = lang == "uk" ? "Адміни" : "Admins";
            string users = lang == "uk" ? "Користувачі" : "Users";
            string active = lang == "uk" ? "Активні" : "Active";
            string blocked = lang == "uk" ? "Заблоковані" : "Blocked";

            var old = SelectedFilter;

            UserFilters.Clear();
            UserFilters.Add(all);
            UserFilters.Add(admins);
            UserFilters.Add(users);
            UserFilters.Add(active);
            UserFilters.Add(blocked);

            SelectedFilter = UserFilters.Contains(old) ? old : UserFilters[0];
        }

        public void LoadUsers()
        {
            using var context = _contextFactory.CreateContext();
            var currentUsername = Settings.Default.username;

            _allUsers = context.Users
                .Where(u => u.Username != "admin" && u.Username != currentUsername)
                .OrderBy(u => u.Id)
                .ToList();

            ApplyFilter();
        }

        private void ApplyFilter()
        {
            string lang = LanguageManager.CurrentLanguage;
            string filter = SelectedFilter ?? (lang == "uk" ? "Всі" : "All");

            IEnumerable<User> filtered = _allUsers;

            if ((lang == "uk" && filter == "Адміни") || (lang != "uk" && filter == "Admins"))
                filtered = filtered.Where(u => u.Role == UserRole.Admin);
            else if ((lang == "uk" && filter == "Користувачі") || (lang != "uk" && filter == "Users"))
                filtered = filtered.Where(u => u.Role == UserRole.User);
            else if ((lang == "uk" && filter == "Активні") || (lang != "uk" && filter == "Active"))
                filtered = filtered.Where(u => u.Status == UserStatus.Active);
            else if ((lang == "uk" && filter == "Заблоковані") || (lang != "uk" && filter == "Blocked"))
                filtered = filtered.Where(u => u.Status == UserStatus.Blocked);

            if (!string.IsNullOrWhiteSpace(SearchQuery))
                filtered = filtered.Where(u => u.Username.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));

            _filteredUsers = filtered.OrderBy(u => u.Id).ToList();

            if (CurrentPage > TotalPages)
                CurrentPage = TotalPages;
            if (CurrentPage < 1)
                CurrentPage = 1;

            LoadPagedUsers();
        }

        private void LoadPagedUsers()
        {
            Users.Clear();

            foreach (var user in _filteredUsers
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize))
            {
                Users.Add(new UserViewModel
                {
                    Id = user.Id,
                    Username = user.Username,
                    Role = user.Role,
                    Status = user.Status
                });
            }

            OnPropertyChanged(nameof(TotalPages));
        }

        private void ChangeRole(object param)
        {
            if (param is UserViewModel u)
            {
                using var context = _contextFactory.CreateContext();
                var user = context.Users.FirstOrDefault(x => x.Id == u.Id);
                if (user != null)
                {
                    user.Role = user.Role == UserRole.User ? UserRole.Admin : UserRole.User;
                    context.SaveChanges();
                    LoadUsers();
                }
            }
        }

        private void ToggleBlock(object param)
        {
            if (param is UserViewModel u)
            {
                using var context = _contextFactory.CreateContext();
                var user = context.Users.FirstOrDefault(x => x.Id == u.Id);
                if (user != null)
                {
                    user.Status = user.Status == UserStatus.Active ? UserStatus.Blocked : UserStatus.Active;
                    context.SaveChanges();
                    LoadUsers();
                }
            }
        }

        private void DeleteUser(object param)
        {
            if (param is not UserViewModel u) return;

            var confirm = new MessageBoxView();
            confirm.TextBlockProblem1.Text = LanguageManager.CurrentLanguage == "uk"
                ? "Ви дійсно бажаєте видалити цього користувача?"
                : "Are you sure you want to delete this user?";
            confirm.ButtonYes.Content = LanguageManager.CurrentLanguage == "uk" ? "Так" : "Yes";
            confirm.ButtonOk.Content = LanguageManager.CurrentLanguage == "uk" ? "Ні" : "No";
            confirm.ButtonYes.Visibility = System.Windows.Visibility.Visible;
            confirm.ButtonOk.Visibility = System.Windows.Visibility.Visible;
            confirm.ButtonNo.Visibility = System.Windows.Visibility.Hidden;
            confirm.IconSuccess.Visibility = System.Windows.Visibility.Hidden;
            confirm.IconThink.Visibility = System.Windows.Visibility.Visible;
            confirm.IconError.Visibility = System.Windows.Visibility.Hidden;
            confirm.ShowDialog();

            if (MessageBoxView.buttonYesClicked != true)
                return;

            try
            {
                using var context = _contextFactory.CreateContext();
                var user = context.Users.FirstOrDefault(x => x.Id == u.Id);
                if (user == null)
                {
                    ShowErrorBox(LanguageManager.CurrentLanguage == "uk"
                        ? "Користувача не знайдено."
                        : "User not found.");
                    return;
                }

                context.Users.Remove(user);
                context.SaveChanges();

                LoadUsers();
                OnPropertyChanged(nameof(Users));

                var success = new MessageBoxView();
                success.TextBlockProblem1.Text = LanguageManager.CurrentLanguage == "uk"
                    ? "Користувача успішно видалено!"
                    : "User deleted successfully!";
                success.ButtonYes.Visibility = System.Windows.Visibility.Hidden;
                success.ButtonNo.Visibility = System.Windows.Visibility.Hidden;
                success.IconError.Visibility = System.Windows.Visibility.Hidden;
                success.IconThink.Visibility = System.Windows.Visibility.Hidden;
                success.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowErrorBox("Помилка при видаленні: " + ex.Message);
            }
            finally
            {
                MessageBoxView.buttonYesClicked = false;
            }
        }

        private void ShowErrorBox(string message)
        {
            var error = new MessageBoxView();
            error.TextBlockProblem1.Text = message;
            error.ButtonYes.Visibility = System.Windows.Visibility.Hidden;
            error.ButtonNo.Visibility = System.Windows.Visibility.Hidden;
            error.IconSuccess.Visibility = System.Windows.Visibility.Hidden;
            error.IconThink.Visibility = System.Windows.Visibility.Hidden;
            error.IconError.Visibility = System.Windows.Visibility.Visible;
            error.ShowDialog();
        }
    }

    public class UserViewModel : ViewModelBase
    {
        public int Id { get; set; }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        private UserRole _role;
        public UserRole Role
        {
            get => _role;
            set
            {
                if (_role != value)
                {
                    _role = value;
                    OnPropertyChanged(nameof(Role));
                }
            }
        }

        private UserStatus _status;
        public UserStatus Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }
    }
}
