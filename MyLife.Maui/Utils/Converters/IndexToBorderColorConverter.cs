using System.Globalization;

namespace MyLife.Maui.Utils.Converters;

/// <summary>
/// Alternates border color based on the index of the item in the list.
/// Caution: Convert back is not implemented.
/// </summary>
public class IndexToBorderColorConverter : IValueConverter
{
    object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (parameter is not BindableObject listview) return Colors.Black;
        if (value is null) return Colors.Black;
        
        var source = BindableLayout.GetItemsSource(listview).Cast<object>().ToList();
        var index = source.IndexOf(value);
        
        return index % 2 == 0 ? Colors.MediumPurple : Colors.MediumAquamarine;
    }
    
    object IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}