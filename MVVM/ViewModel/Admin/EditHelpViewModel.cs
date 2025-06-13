using A_journey_through_miniature_Uzhhorod.MVVM.View;
using A_journey_through_miniature_Uzhhorod.Properties;
using A_journey_through_miniature_Uzhhorod.Resources;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel.Admin
{
    public class EditHelpViewModel : ViewModelBase
    {
        private string _helpText;
        private string _currentLanguageCode = "uk";
        private readonly string _basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Txt");

        public string HelpText
        {
            get => _helpText;
            set
            {
                _helpText = value;
                OnPropertyChanged(nameof(HelpText));
            }
        }

        public string CurrentLanguageCode
        {
            get => _currentLanguageCode;
            set
            {
                _currentLanguageCode = value;
                OnPropertyChanged(nameof(CurrentLanguageCode));
                LoadTextForLanguage(value);
            }
        }

        public ICommand SaveCommand { get; }

        public EditHelpViewModel()
        {
            SaveCommand = new RelayCommand(_ => SaveText());
            LoadTextForLanguage(_currentLanguageCode);
        }

        public void LoadTextForLanguage(string langCode)
        {
            try
            {
                _currentLanguageCode = langCode;
                string filePath = Path.Combine(_basePath, $"help_{langCode}.txt");
                if (!File.Exists(filePath))
                {
                    File.WriteAllText(filePath, "");
                }
                else
                {
                    HelpText = _currentLanguageCode == "en" ? "Help file not found." : "Файл довідки не знайдено.";
                }
                HelpText = File.ReadAllText(filePath);
            }
            catch (IOException ex)
            {
                HelpText = Settings.Default.LanguageCode == "en"
                    ? "Error while loading help file."
                    : "Помилка під час завантаження довідки.";
            }
        }

        public void SaveText()
        {
            try
            {
                string filePath = Path.Combine(_basePath, $"help_{_currentLanguageCode}.txt");
                File.WriteAllText(filePath, HelpText);
                ShowSuccessMessageBox(Strings.FileSavedSuccessfully);
            }
            catch (IOException ex)
            {
                ShowErrorMessageBox($"{Strings.ErrorWhileSaving} {ex.Message}");
            }
        }


        private void ShowErrorMessageBox(string text)
        {
            MessageBoxView messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = text;
            messageBoxView.ButtonYes.Visibility = Visibility.Hidden;
            messageBoxView.ButtonNo.Visibility = Visibility.Hidden;
            messageBoxView.IconSuccess.Visibility = Visibility.Hidden;
            messageBoxView.IconThink.Visibility = Visibility.Hidden;
            messageBoxView.ShowDialog();
        }

        private void ShowSuccessMessageBox(string text)
        {
            MessageBoxView messageBoxView = new MessageBoxView();
            messageBoxView.TextBlockProblem1.Text = text;
            messageBoxView.ButtonYes.Visibility = Visibility.Hidden;
            messageBoxView.ButtonNo.Visibility = Visibility.Hidden;
            messageBoxView.IconError.Visibility = Visibility.Hidden;
            messageBoxView.IconThink.Visibility = Visibility.Hidden;
            messageBoxView.ShowDialog();
        }
    }
}
