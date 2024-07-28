using System.Globalization;

namespace MyLife.Maui.Utils.Converters;

/// <summary>
/// Alternates border radius in tear shape based on the index of the item in the list.
/// Caution: Convert back is not implemented.
/// </summary>
public class IndexToTearBorderRadiusConverter: IValueConverter
{
    #region Constants
    
    private readonly CornerRadius even = new CornerRadius(24, 6, 6, 24);
    private readonly CornerRadius odd = new CornerRadius(6, 24, 24, 6);
    
    #endregion

    #region  IValueConverter implementation

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (parameter is not BindableObject listview) return even;
        if (value is null) return even;
        
        var source = BindableLayout.GetItemsSource(listview).Cast<object>().ToList();
        var index = source.IndexOf(value);
        
        return index % 2 == 0 ? even : odd;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    #endregion
}

