using System.Globalization;
using System.Windows.Data;

namespace Raxer_2_alpha.Utilidades;

public class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is bool booleanValue)
        {
            return booleanValue ? Visibility.Visible : Visibility.Collapsed;
        }

        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is Visibility visibility)
        {
            return visibility == Visibility.Visible;
        }

        return false;
    }
}

