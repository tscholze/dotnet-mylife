using System.Globalization;

namespace MyLife.Maui.Utils.Converters;

/// <summary>
/// Alternates border color based on the index of the item in the list.
/// Caution: Convert back is not implemented.
/// </summary>
public class IndexToBorderColorConverter : IValueConverter
{
    /// <summary>
    /// Converts the index of an item in a list to a border color.
    /// </summary>
    /// <param name="value">The current item.</param>
    /// <param name="targetType">The type of the target property.</param>
    /// <param name="parameter">The bindable object containing the list.</param>
    /// <param name="culture">The culture to use for conversion.</param>
    /// <returns>The calculated border color.</returns>
    object? IValueConverter.Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (parameter is not BindableObject listview) return Colors.Black;
        if (value is null) return Colors.Black;
        
        var source = BindableLayout.GetItemsSource(listview).Cast<object>().ToList();
        var index = source.IndexOf(value);
        
        return index % 2 == 0 ? Colors.MediumPurple : Colors.MediumAquamarine;
    }
    
    /// <summary>
    /// Not implemented conversion back from color to index.
    /// </summary>
    /// <exception cref="NotImplementedException">Always throws as conversion back is not supported.</exception>
    object IValueConverter.ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}