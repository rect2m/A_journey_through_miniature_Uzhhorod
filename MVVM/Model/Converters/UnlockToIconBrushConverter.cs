using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters
{
    public class UnlockToIconBrushConverter : IValueConverter
    {
        public Brush UnlockedColor { get; set; } = Brushes.Green;
        public Brush LockedColor { get; set; } = Brushes.Gray;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isUnlocked = value is bool b && b;
            return isUnlocked ? UnlockedColor : LockedColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
