
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters
{
    public class UnlockToBrushConverter : IValueConverter
    {
        public Brush UnlockedBrush { get; set; } = new SolidColorBrush(Color.FromRgb(230, 255, 230)); // світло-зелений
        public Brush LockedBrush { get; set; } = new SolidColorBrush(Color.FromRgb(240, 240, 240));   // сірий

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isUnlocked = value is bool b && b;
            return isUnlocked ? UnlockedBrush : LockedBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
