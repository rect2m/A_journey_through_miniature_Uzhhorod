using A_journey_through_miniature_Uzhhorod.Resources;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Windows.Data;
using System.Windows.Markup;

namespace A_journey_through_miniature_Uzhhorod.MVVM.Model
{
    public class LocExtension : MarkupExtension
    {
        public string Key { get; set; }
        public static readonly ResourceManager _resourceManager = Strings.ResourceManager;

        public LocExtension(string key)
        {
            Key = key;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding($"[{Key}]")
            {
                Source = LanguageResource.Instance,
                Mode = BindingMode.OneWay
            };
            return binding.ProvideValue(serviceProvider);
        }
    }

    public class LanguageResource : INotifyPropertyChanged
    {
        private static LanguageResource _instance;
        public static LanguageResource Instance => _instance ??= new LanguageResource();

        // ✅ Оголошення ResourceManager
        private static readonly ResourceManager _resourceManager = A_journey_through_miniature_Uzhhorod.Resources.Strings.ResourceManager;

        public string this[string key] =>
            _resourceManager.GetString(key, new CultureInfo(LanguageManager.CurrentLanguage)) ?? $"!{key}!";

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseLanguageChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }

}
