using A_journey_through_miniature_Uzhhorod.MVVM.Model;
using A_journey_through_miniature_Uzhhorod.Properties;
using A_journey_through_miniature_Uzhhorod.Resources;
using System.Globalization;

public static class LanguageManager
{
    public static event Action LanguageChanged;

    public static string CurrentLanguage
    {
        get => Settings.Default.LanguageCode ?? "uk";
        set
        {
            if (Settings.Default.LanguageCode != value)
            {
                Settings.Default.LanguageCode = value;
                Settings.Default.Save();

                var culture = new CultureInfo(value);
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
                Thread.CurrentThread.CurrentCulture = culture;
                Thread.CurrentThread.CurrentUICulture = culture;

                LanguageChanged?.Invoke();
                LanguageResource.Instance.RaiseLanguageChanged();
            }
        }
    }

    public static void ToggleLanguage()
    {
        CurrentLanguage = CurrentLanguage == "uk" ? "en" : "uk";
    }

    public static string DisplayLanguage => CurrentLanguage == "uk" ? "УКР" : "ENG";

    public static void NotifyLanguageChanged()
    {
        LanguageChanged?.Invoke();
    }

    public static string GetString(string key)
    {
        return Strings.ResourceManager.GetString(key, new CultureInfo(CurrentLanguage)) ?? $"!{key}!";
    }
}
