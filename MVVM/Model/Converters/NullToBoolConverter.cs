using System.Globalization;
using System.Windows.Data;

namespace A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters
{
    public class NullToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            value != null;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
