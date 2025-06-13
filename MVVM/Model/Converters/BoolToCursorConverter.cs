using System.Globalization;
using System.Windows.Data;
using System.Windows.Input;

namespace A_journey_through_miniature_Uzhhorod.MVVM.Model.Converters
{
    public class BoolToCursorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isClickable)
            {
                return isClickable ? Cursors.Hand : Cursors.Arrow;
            }

            return Cursors.Arrow;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
