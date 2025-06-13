using A_journey_through_miniature_Uzhhorod.Database;
using A_journey_through_miniature_Uzhhorod.Database.Models.Translation;
using A_journey_through_miniature_Uzhhorod.MVVM.Model.Service;
using A_journey_through_miniature_Uzhhorod.MVVM.View;
using A_journey_through_miniature_Uzhhorod.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel.Admin
{
    public class MiniatureEditDetailsViewModel : ViewModelBase
    {
        private readonly IAppDbContextFactory _contextFactory;
        private readonly BlobStorageService _blobStorageService;

        public event Action<ViewModelBase?>? OnNavigateBack;
        public Action? OnSavedSuccessfully { get; set; }

        public MiniatureViewModel SelectedMiniature { get; set; } = new();

        public ICommand BackToListCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand ChangeImageCommand { get; }
        public ICommand ChangeModelCommand { get; }

        private bool _isSaving;
        public bool IsSaving
        {
            get => _isSaving;
            set
            {
                _isSaving = value;
                OnPropertyChanged(nameof(IsSaving));
            }
        }

        public MiniatureEditDetailsViewModel(IAppDbContextFactory contextFactory, BlobStorageService blobStorageService)
        {
            _contextFactory = contextFactory;
            _blobStorageService = blobStorageService;

            BackToListCommand = new ViewModelCommand(_ => OnNavigateBack?.Invoke(null));
            SaveCommand = new ViewModelCommand(async _ => await SaveChangesAsync());
            DeleteCommand = new ViewModelCommand(async _ => await DeleteMiniatureAsync());
            ChangeImageCommand = new ViewModelCommand(_ => ChangeImage());
            ChangeModelCommand = new ViewModelCommand(_ => ChangeModel());

            LanguageManager.LanguageChanged += OnLanguageChanged;
        }

        ~MiniatureEditDetailsViewModel()
        {
            LanguageManager.LanguageChanged -= OnLanguageChanged;
        }

        private void OnLanguageChanged()
        {
            string langCode = Settings.Default.LanguageCode;

            if (SelectedMiniature != null && SelectedMiniature.AvailableLanguages.Contains(langCode))
            {
                SelectedMiniature.SelectedLanguage = langCode;
                SelectedMiniature.OnPropertyChanged(nameof(SelectedMiniature.Name));
                SelectedMiniature.OnPropertyChanged(nameof(SelectedMiniature.Description));
            }
        }

        public void LoadMiniature(int miniatureId)
        {
            using var context = _contextFactory.CreateContext();
            var miniature = context.Miniatures
    .Where(m => m.Id == miniatureId)
    .Select(m => new MiniatureViewModel
    {
        Id = m.Id,
        Latitude = m.Latitude,
        Longitude = m.Longitude,
        ImageUrl = m.ImageUrl,
        ImagePath = m.ImageUrl,
        ModelUrl = m.ModelUrl ?? "",
        NameUk = m.Translations.FirstOrDefault(t => t.LanguageCode == "uk")!.Name,
        DescriptionUk = m.Translations.FirstOrDefault(t => t.LanguageCode == "uk")!.Description,
        NameEn = m.Translations.FirstOrDefault(t => t.LanguageCode == "en")!.Name,
        DescriptionEn = m.Translations.FirstOrDefault(t => t.LanguageCode == "en")!.Description
    }).FirstOrDefault();


            if (miniature != null)
            {
                SelectedMiniature = miniature;
                SelectedMiniature.LoadImageAsync();
                OnPropertyChanged(nameof(SelectedMiniature));
                OnPropertyChanged(nameof(SelectedMiniature.ImageSource));
            }
        }

        private async Task SaveChangesAsync()
        {
            if (SelectedMiniature.HasErrors)
            {
                ShowErrorMessageBox("Будь ласка, заповніть всі обов’язкові поля перед збереженням.");
                return;
            }

            IsSaving = true;

            try
            {
                using var context = _contextFactory.CreateContext();
                var entity = context.Miniatures
                    .Include(m => m.Translations)
                    .FirstOrDefault(m => m.Id == SelectedMiniature.Id);

                if (entity == null)
                {
                    entity = new Database.Models.Miniature
                    {
                        Latitude = SelectedMiniature.Latitude,
                        Longitude = SelectedMiniature.Longitude,
                        ModelUrl = "",
                        ImageUrl = "",
                        Translations = new List<MiniatureTranslation>
                {
                    new()
                    {
                        LanguageCode = "uk",
                        Name = SelectedMiniature.NameUk,
                        Description = SelectedMiniature.DescriptionUk
                    },
                    new()
                    {
                        LanguageCode = "en",
                        Name = SelectedMiniature.NameEn,
                        Description = SelectedMiniature.DescriptionEn
                    }
                }
                    };
                    context.Miniatures.Add(entity);
                }
                else
                {
                    entity.Latitude = SelectedMiniature.Latitude;
                    entity.Longitude = SelectedMiniature.Longitude;

                    var translations = entity.Translations.ToList();

                    var uk = translations.FirstOrDefault(t => t.LanguageCode == "uk");
                    if (uk != null)
                    {
                        uk.Name = SelectedMiniature.NameUk;
                        uk.Description = SelectedMiniature.DescriptionUk;
                    }
                    else
                    {
                        entity.Translations.Add(new MiniatureTranslation
                        {
                            LanguageCode = "uk",
                            Name = SelectedMiniature.NameUk,
                            Description = SelectedMiniature.DescriptionUk
                        });
                    }

                    var en = translations.FirstOrDefault(t => t.LanguageCode == "en");
                    if (en != null)
                    {
                        en.Name = SelectedMiniature.NameEn;
                        en.Description = SelectedMiniature.DescriptionEn;
                    }
                    else
                    {
                        entity.Translations.Add(new MiniatureTranslation
                        {
                            LanguageCode = "en",
                            Name = SelectedMiniature.NameEn,
                            Description = SelectedMiniature.DescriptionEn
                        });
                    }
                }

                // Зображення
                if (!string.IsNullOrWhiteSpace(SelectedMiniature.ImagePath) && File.Exists(SelectedMiniature.ImagePath))
                {
                    if (!string.IsNullOrWhiteSpace(entity.ImageUrl))
                    {
                        string previousFileName = Path.GetFileName(entity.ImageUrl);
                        await _blobStorageService.DeleteFileAsync(previousFileName, "images");
                    }

                    string fileName = $"miniature_{Guid.NewGuid()}{Path.GetExtension(SelectedMiniature.ImagePath)}";
                    await using var stream = File.OpenRead(SelectedMiniature.ImagePath);
                    await _blobStorageService.UploadFileAsync(stream, fileName, "images");

                    string blobUrl = _blobStorageService.GetBlobUrl(fileName, "images");
                    entity.ImageUrl = blobUrl;
                    SelectedMiniature.ImageUrl = blobUrl;
                    SelectedMiniature.ImagePath = blobUrl;
                }

                // 3D-модель
                if (!string.IsNullOrWhiteSpace(SelectedMiniature.ModelFolderPath) && Directory.Exists(SelectedMiniature.ModelFolderPath))
                {
                    if (!string.IsNullOrWhiteSpace(entity.ModelUrl))
                    {
                        string previousDirName = Path.GetFileName(Path.GetDirectoryName(entity.ModelUrl));
                        await _blobStorageService.DeleteDirectoryAsync(previousDirName, "3d-models");
                    }

                    string modelFolderName = $"model_{Guid.NewGuid()}";
                    await _blobStorageService.UploadDirectoryAsync(SelectedMiniature.ModelFolderPath, modelFolderName, "3d-models");

                    string objFile = Directory.GetFiles(SelectedMiniature.ModelFolderPath, "*.obj").FirstOrDefault();
                    if (objFile != null)
                    {
                        string blobUrl = _blobStorageService.GetBlobUrl($"{modelFolderName}/{Path.GetFileName(objFile)}", "3d-models");
                        entity.ModelUrl = blobUrl;
                        SelectedMiniature.ModelUrl = blobUrl;
                    }
                }

                await context.SaveChangesAsync();

                ShowSuccessMessageBox("Мініскульптурку успішно збережено.");
                OnSavedSuccessfully?.Invoke();
                OnNavigateBack?.Invoke(null);
            }
            catch (Exception ex)
            {
                ShowErrorMessageBox($"Помилка під час збереження: {ex.Message}");
            }
            finally
            {
                IsSaving = false;
            }
        }

        private async Task DeleteMiniatureAsync()
        {
            // Підтвердження видалення
            var confirmBox = new MessageBoxView
            {
                TextBlockProblem1 = { Text = "Ви дійсно хочете видалити цю мініскульптурку?" }
            };
            confirmBox.ButtonYes.Content = "Так";
            confirmBox.ButtonOk.Content = "Ні";
            confirmBox.ButtonYes.Visibility = Visibility.Visible;
            confirmBox.ButtonOk.Visibility = Visibility.Visible;
            confirmBox.ButtonNo.Visibility = Visibility.Hidden;
            confirmBox.IconSuccess.Visibility = Visibility.Hidden;
            confirmBox.IconThink.Visibility = Visibility.Visible;
            confirmBox.IconError.Visibility = Visibility.Hidden;
            confirmBox.ShowDialog();

            if (MessageBoxView.buttonYesClicked != true)
            {
                MessageBoxView.buttonYesClicked = false;
                return;
            }

            MessageBoxView.buttonYesClicked = false;

            try
            {
                using var context = _contextFactory.CreateContext();
                var entity = context.Miniatures.FirstOrDefault(m => m.Id == SelectedMiniature.Id);
                if (entity != null)
                {
                    if (!string.IsNullOrWhiteSpace(entity.ImageUrl))
                    {
                        string fileName = Path.GetFileName(entity.ImageUrl);
                        await _blobStorageService.DeleteFileAsync(fileName, "images");
                    }

                    if (!string.IsNullOrWhiteSpace(entity.ModelUrl))
                    {
                        string modelFolder = Path.GetFileName(Path.GetDirectoryName(entity.ModelUrl));
                        await _blobStorageService.DeleteDirectoryAsync(modelFolder, "3d-models");
                    }

                    context.Miniatures.Remove(entity);
                    await context.SaveChangesAsync();
                }

                var successBox = new MessageBoxView
                {
                    TextBlockProblem1 = { Text = "Мініскульптурку успішно видалено." }
                };
                successBox.ButtonYes.Visibility = Visibility.Hidden;
                successBox.ButtonNo.Visibility = Visibility.Hidden;
                successBox.ButtonOk.Visibility = Visibility.Visible;
                successBox.IconSuccess.Visibility = Visibility.Visible;
                successBox.IconError.Visibility = Visibility.Hidden;
                successBox.IconThink.Visibility = Visibility.Hidden;
                successBox.ShowDialog();

                OnSavedSuccessfully?.Invoke();
                OnNavigateBack?.Invoke(null);
            }
            catch (Exception ex)
            {
                var errorBox = new MessageBoxView
                {
                    TextBlockProblem1 = { Text = $"Помилка при видаленні: {ex.Message}" }
                };
                errorBox.ButtonYes.Visibility = Visibility.Hidden;
                errorBox.ButtonNo.Visibility = Visibility.Hidden;
                errorBox.ButtonOk.Visibility = Visibility.Visible;
                errorBox.IconSuccess.Visibility = Visibility.Hidden;
                errorBox.IconError.Visibility = Visibility.Visible;
                errorBox.IconThink.Visibility = Visibility.Hidden;
                errorBox.ShowDialog();
            }
        }

        private void ChangeModel()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Title = "Оберіть .obj файл моделі",
                Filter = "3D Model Files (*.obj)|*.obj",
                Multiselect = false
            };

            if (dialog.ShowDialog() == true)
            {
                string objFilePath = dialog.FileName;
                string modelFolder = Path.GetDirectoryName(objFilePath)!;

                SelectedMiniature.ModelPath = objFilePath;
                SelectedMiniature.ModelFolderPath = modelFolder;
                SelectedMiniature.ModelUrl = "";

                OnPropertyChanged(nameof(SelectedMiniature));
            }
        }

        private void ChangeImage()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg"
            };

            if (dialog.ShowDialog() == true)
            {
                SelectedMiniature.ImagePath = dialog.FileName;
                SelectedMiniature.LoadImageAsync();
                OnPropertyChanged(nameof(SelectedMiniature));
                OnPropertyChanged(nameof(SelectedMiniature.ImageSource));
            }
        }

        public class MiniatureViewModel : ViewModelBase, IDataErrorInfo
        {
            public int Id { get; set; }

            public double Latitude { get; set; }
            public double Longitude { get; set; }

            public string ImageUrl { get; set; } = string.Empty;
            public string ImagePath { get; set; } = string.Empty;

            public string ModelUrl { get; set; } = string.Empty;
            public string ModelPath { get; set; } = string.Empty;
            public string ModelFolderPath { get; set; } = string.Empty;

            public string NameUk { get; set; } = string.Empty;
            public string DescriptionUk { get; set; } = string.Empty;
            public string NameEn { get; set; } = string.Empty;
            public string DescriptionEn { get; set; } = string.Empty;

            public List<string> AvailableLanguages => new() { "uk", "en" };

            private string _selectedLanguage = "uk";
            public string SelectedLanguage
            {
                get => _selectedLanguage;
                set
                {
                    if (_selectedLanguage != value)
                    {
                        _selectedLanguage = value;
                        OnPropertyChanged(nameof(SelectedLanguage));
                        OnPropertyChanged(nameof(Name));
                        OnPropertyChanged(nameof(Description));
                    }
                }
            }

            public string Name
            {
                get => SelectedLanguage == "en" ? NameEn : NameUk;
                set
                {
                    if (SelectedLanguage == "en")
                    {
                        if (IsEnglishOnly(value))
                        {
                            NameEn = value;
                            OnPropertyChanged(nameof(Name));
                        }
                    }
                    else
                    {
                        NameUk = value;
                        OnPropertyChanged(nameof(Name));
                    }
                }
            }

            public string Description
            {
                get => SelectedLanguage == "en" ? DescriptionEn : DescriptionUk;
                set
                {
                    if (SelectedLanguage == "en")
                    {
                        if (IsEnglishOnly(value))
                        {
                            DescriptionEn = value;
                            OnPropertyChanged(nameof(Description));
                        }
                    }
                    else
                    {
                        DescriptionUk = value;
                        OnPropertyChanged(nameof(Description));
                    }
                }
            }


            private BitmapImage _image;
            public BitmapImage ImageSource
            {
                get => _image ?? new BitmapImage(new Uri("https://minisculptures.blob.core.windows.net/images/notFound.png"));
                private set
                {
                    _image = value;
                    OnPropertyChanged(nameof(ImageSource));
                }
            }

            private bool IsEnglishOnly(string input)
            {
                return string.IsNullOrWhiteSpace(input) || System.Text.RegularExpressions.Regex.IsMatch(input, @"^[\x00-\x7F]*$");
            }


            public async void LoadImageAsync()
            {
                const string placeholderUrl = "https://minisculptures.blob.core.windows.net/images/notFound.png";

                try
                {
                    if (string.IsNullOrWhiteSpace(ImagePath))
                    {
                        await LoadFromUrlAsync(placeholderUrl);
                        return;
                    }

                    if (File.Exists(ImagePath))
                    {
                        await Application.Current.Dispatcher.InvokeAsync(() =>
                        {
                            try
                            {
                                var bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                                bitmap.UriSource = new Uri(ImagePath, UriKind.Absolute);
                                bitmap.EndInit();
                                bitmap.Freeze();
                                ImageSource = bitmap;
                            }
                            catch
                            {
                                _ = LoadFromUrlAsync(placeholderUrl);
                            }
                        });
                    }
                    else if (Uri.TryCreate(ImagePath, UriKind.Absolute, out var uri) && uri.Scheme.StartsWith("http"))
                    {
                        await LoadFromUrlAsync(ImagePath);
                    }
                    else
                    {
                        await LoadFromUrlAsync(placeholderUrl);
                    }
                }
                catch
                {
                    await LoadFromUrlAsync(placeholderUrl);
                }
            }

            private async Task LoadFromUrlAsync(string url)
            {
                try
                {
                    string cacheDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MiniatureCache");
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
                        ImageSource = bitmap;
                    });
                }
                catch { }
            }

            public string Error => null;

            public string this[string columnName]
            {
                get
                {
                    return columnName switch
                    {
                        nameof(NameUk) when string.IsNullOrWhiteSpace(NameUk) => "Назва українською обов’язкова.",
                        nameof(DescriptionUk) when string.IsNullOrWhiteSpace(DescriptionUk) => "Опис українською обов’язковий.",
                        nameof(NameEn) when string.IsNullOrWhiteSpace(NameEn) => "Назва англійською обов’язкова.",
                        nameof(DescriptionEn) when string.IsNullOrWhiteSpace(DescriptionEn) => "Опис англійською обов’язковий.",
                        nameof(Latitude) when Latitude is < -90 or > 90 => "Широта повинна бути між -90 та 90.",
                        nameof(Longitude) when Longitude is < -180 or > 180 => "Довгота повинна бути між -180 та 180.",
                        _ => null
                    };
                }
            }

            public bool HasErrors =>
                !string.IsNullOrWhiteSpace(this[nameof(NameUk)]) ||
                !string.IsNullOrWhiteSpace(this[nameof(DescriptionUk)]) ||
                !string.IsNullOrWhiteSpace(this[nameof(NameEn)]) ||
                !string.IsNullOrWhiteSpace(this[nameof(DescriptionEn)]) ||
                !string.IsNullOrWhiteSpace(this[nameof(Latitude)]) ||
                !string.IsNullOrWhiteSpace(this[nameof(Longitude)]);
        }

        private void ShowErrorMessageBox(string text)
        {
            var messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = text;
            messageBoxView.ButtonYes.Visibility = Visibility.Hidden;
            messageBoxView.ButtonNo.Visibility = Visibility.Hidden;
            messageBoxView.ButtonOk.Visibility = Visibility.Visible;
            messageBoxView.IconSuccess.Visibility = Visibility.Hidden;
            messageBoxView.IconThink.Visibility = Visibility.Hidden;
            messageBoxView.IconError.Visibility = Visibility.Visible;
            messageBoxView.ShowDialog();
        }

        private void ShowSuccessMessageBox(string text)
        {
            var messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = text;
            messageBoxView.ButtonYes.Visibility = Visibility.Hidden;
            messageBoxView.ButtonNo.Visibility = Visibility.Hidden;
            messageBoxView.ButtonOk.Visibility = Visibility.Visible;
            messageBoxView.IconSuccess.Visibility = Visibility.Visible;
            messageBoxView.IconThink.Visibility = Visibility.Hidden;
            messageBoxView.IconError.Visibility = Visibility.Hidden;
            messageBoxView.ShowDialog();
        }
    }
}