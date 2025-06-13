using A_journey_through_miniature_Uzhhorod.Properties;
using System.IO;

namespace A_journey_through_miniature_Uzhhorod.MVVM.ViewModel
{
    public class HelpViewModel : ViewModelBase
    {
        private string _helpText;

        public string HelpText
        {
            get => _helpText;
            set
            {
                _helpText = value;
                OnPropertyChanged(nameof(HelpText));
            }
        }

        public HelpViewModel()
        {
            LoadHelpText();

            LanguageManager.LanguageChanged += LoadHelpText;
        }

        public void LoadHelpText()
        {
            try
            {
                string lang = Settings.Default.LanguageCode;
                string fileName = lang == "en" ? "help_en.txt" : "help_uk.txt";
                string filePath = Path.Combine("Txt", fileName);

                if (File.Exists(filePath))
                    HelpText = File.ReadAllText(filePath);
                else
                    HelpText = lang == "en" ? "Help file not found." : "Файл довідки не знайдено.";
            }
            catch
            {
                HelpText = Settings.Default.LanguageCode == "en"
                    ? "Error while loading help file."
                    : "Помилка під час завантаження довідки.";
            }
        }
    }
}
