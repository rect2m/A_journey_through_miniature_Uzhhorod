using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Properties;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel.Admin
{
    public class EditSculptureViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;
        private readonly MiniatureEditDetailsViewModel _detailsViewModel;
        private const int PageSize = 15;

        public event Action<ViewModelBase>? OnNavigate;

        public ObservableCollection<MiniatureViewModel> PagedMiniatures { get; set; } = new();
        private List<MiniatureViewModel> _allMiniatures = new();
        private List<MiniatureViewModel> _filteredMiniatures = new();

        public ICommand OpenAddDetailsViewCommand { get; }
        public ICommand OpenDetailsViewCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand NextPageCommand { get; }
        public ICommand PrevPageCommand { get; }

        private string _searchQuery = string.Empty;
        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged(nameof(SearchQuery));
                ApplyFilterAndPagination();
            }
        }

        private int _currentPage = 1;
        public int CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
                LoadPagedMiniatures();
            }
        }

        public int TotalPages => (int)Math.Ceiling((double)_filteredMiniatures.Count / PageSize);

        private int _totalMiniaturesCount;
        public int TotalMiniaturesCount
        {
            get => _totalMiniaturesCount;
            set
            {
                _totalMiniaturesCount = value;
                OnPropertyChanged(nameof(TotalMiniaturesCount));
            }
        }

        public EditSculptureViewModel(IAppDbContextFactory contextFactory, MiniatureEditDetailsViewModel detailsViewModel)
        {
            _contextFactory = contextFactory;
            _detailsViewModel = detailsViewModel;
            _detailsViewModel.OnNavigateBack += _ =>
            {
                LoadMiniatures();
                OnNavigate?.Invoke(this);
            };

            OpenAddDetailsViewCommand = new ViewModelCommand(_ =>
            {
                _detailsViewModel.SelectedMiniature = new MiniatureEditDetailsViewModel.MiniatureViewModel
                {
                    Id = 0,
                    Name = "",
                    Description = "",
                    Latitude = 0,
                    Longitude = 0,
                    ImagePath = "",
                    ImageUrl = "",
                    ModelUrl = ""
                };
                OnNavigate?.Invoke(_detailsViewModel);
            });

            OpenDetailsViewCommand = new ViewModelCommand(obj =>
            {
                if (obj is MiniatureViewModel m)
                {
                    _detailsViewModel.LoadMiniature(m.Id);
                    OnNavigate?.Invoke(_detailsViewModel);
                }
            });

            DeleteCommand = new ViewModelCommand(obj =>
            {
                if (obj is MiniatureViewModel m)
                    DeleteMiniature(m);
            });

            NextPageCommand = new ViewModelCommand(_ => { if (CurrentPage < TotalPages) CurrentPage++; });
            PrevPageCommand = new ViewModelCommand(_ => { if (CurrentPage > 1) CurrentPage--; });

            LanguageManager.LanguageChanged += OnLanguageChanged;

            LoadMiniatures();
        }

        private void OnLanguageChanged()
        {
            LoadMiniatures();
        }

        private void LoadMiniatures()
        {
            using var context = _contextFactory.CreateContext();
            _allMiniatures.Clear();

            string langCode = Settings.Default.LanguageCode;

            var miniatures = context.Miniatures.Include(m => m.Translations).AsNoTracking().ToList();

            foreach (var miniature in miniatures)
            {
                var translation = miniature.Translations.FirstOrDefault(t => t.LanguageCode == langCode);
                if (translation != null)
                {
                    var imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, miniature.ImageUrl);
                    var modelUrl = miniature.ModelUrl?.StartsWith("http", StringComparison.OrdinalIgnoreCase) == true
                        ? miniature.ModelUrl.Replace("\\", "/")
                        : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, miniature.ModelUrl);

                    _allMiniatures.Add(new MiniatureViewModel
                    {
                        Id = miniature.Id,
                        Name = translation.Name,
                        Description = translation.Description,
                        Latitude = miniature.Latitude,
                        Longitude = miniature.Longitude,
                        ImagePath = miniature.ImageUrl,
                        ModelUrl = modelUrl
                    });
                }
            }

            TotalMiniaturesCount = _allMiniatures.Count;
            ApplyFilterAndPagination();
        }

        private void ApplyFilterAndPagination()
        {
            var filtered = _allMiniatures.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(SearchQuery))
                filtered = filtered.Where(m => m.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase));

            _filteredMiniatures = filtered.ToList();
            CurrentPage = 1;
            LoadPagedMiniatures();
            OnPropertyChanged(nameof(TotalPages));
        }

        private void LoadPagedMiniatures()
        {
            PagedMiniatures.Clear();
            foreach (var item in _filteredMiniatures.Skip((CurrentPage - 1) * PageSize).Take(PageSize))
            {
                item.LoadImageAsync();
                PagedMiniatures.Add(item);
            }
        }

        private void DeleteMiniature(MiniatureViewModel m)
        {
            using var context = _contextFactory.CreateContext();
            var entity = context.Miniatures.FirstOrDefault(x => x.Id == m.Id);
            if (entity != null)
            {
                context.Miniatures.Remove(entity);
                context.SaveChanges();
                LoadMiniatures();
            }
        }

        public class MiniatureViewModel : ViewModelBase
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string ImagePath { get; set; } = string.Empty;
            public string ModelUrl { get; set; } = string.Empty;

            private BitmapImage _image;
            public BitmapImage ImageSource
            {
                get => _image;
                private set
                {
                    _image = value;
                    OnPropertyChanged(nameof(ImageSource));
                }
            }

            public async void LoadImageAsync()
            {
                const string blobFallbackUrl = "https://minisculptures.blob.core.windows.net/images/notFound.png";
                string cacheDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MiniatureCache");
                Directory.CreateDirectory(cacheDir);

                string fallbackPath = Path.Combine(cacheDir, "notFound.png");

                if (!File.Exists(fallbackPath))
                {
                    try
                    {
                        using var client = new System.Net.WebClient();
                        await client.DownloadFileTaskAsync(blobFallbackUrl, fallbackPath);
                    }
                    catch { }
                }

                try
                {
                    string imageToLoad = null;

                    if (string.IsNullOrWhiteSpace(ImagePath))
                    {
                        imageToLoad = fallbackPath;
                    }
                    else if (Uri.TryCreate(ImagePath, UriKind.Absolute, out var uri) && uri.Scheme.StartsWith("http"))
                    {
                        string fileName = Path.GetFileName(uri.LocalPath);
                        string localPath = Path.Combine(cacheDir, fileName);

                        if (!File.Exists(localPath))
                        {
                            try
                            {
                                using var client = new System.Net.WebClient();
                                await client.DownloadFileTaskAsync(uri, localPath);
                            }
                            catch
                            {
                                imageToLoad = fallbackPath;
                            }
                        }

                        if (File.Exists(localPath))
                            imageToLoad = localPath;
                    }
                    else
                    {
                        string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                        string fullPath = Path.IsPathRooted(ImagePath) ? ImagePath : Path.Combine(baseDir, ImagePath);
                        if (File.Exists(fullPath))
                            imageToLoad = fullPath;
                        else
                            imageToLoad = fallbackPath;
                    }

                    if (string.IsNullOrWhiteSpace(imageToLoad) || !File.Exists(imageToLoad))
                        imageToLoad = fallbackPath;

                    await Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        try
                        {
                            var bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.CacheOption = BitmapCacheOption.OnLoad;
                            bitmap.UriSource = new Uri(imageToLoad, UriKind.Absolute);
                            bitmap.EndInit();
                            bitmap.Freeze();
                            ImageSource = bitmap;
                        }
                        catch
                        {
                            var fallback = new BitmapImage();
                            fallback.BeginInit();
                            fallback.UriSource = new Uri(fallbackPath, UriKind.Absolute);
                            fallback.CacheOption = BitmapCacheOption.OnLoad;
                            fallback.EndInit();
                            fallback.Freeze();
                            ImageSource = fallback;
                        }
                    });
                }
                catch
                {
                    ImageSource = new BitmapImage(new Uri(fallbackPath, UriKind.Absolute));
                }
            }
        }
    }
}