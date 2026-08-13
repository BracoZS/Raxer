using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Raxer.Infra.Shared;

public sealed class BoolToVisibilityConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        bool invert = string.Equals(parameter as string, "invert", StringComparison.OrdinalIgnoreCase);
        bool isTrue = value is true;
        return invert
            ? (isTrue ? Visibility.Collapsed : Visibility.Visible)
            : (isTrue ? Visibility.Visible : Visibility.Collapsed);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}

public sealed class NullToVisibilityConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        bool invert = string.Equals(parameter as string, "invert", StringComparison.OrdinalIgnoreCase);
        bool isNull = value is null;
        return invert
            ? (isNull ? Visibility.Visible : Visibility.Collapsed)
            : (isNull ? Visibility.Collapsed : Visibility.Visible);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
