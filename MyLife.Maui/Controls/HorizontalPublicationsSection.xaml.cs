using MyLife.Core.Models.ContentCreation;

namespace MyLife.Maui.Controls;

public partial class HorizontalPublicationsSection : VerticalStackLayout
{
    #region BindableProperty
    
    /// <summary>
    /// Bindable Items property.
    /// </summary>
    public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items),
        typeof(IEnumerable<AccountPublications>), typeof(HorizontalPublicationsSection));
    
    /// <summary>
    /// Bindable border color property.
    /// </summary>
    private static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor),
        typeof(Color), typeof(HorizontalPublicationsSection));
    
    #endregion

    #region Constructor
    
    public HorizontalPublicationsSection()
    {
        InitializeComponent();
    }
    
    #endregion

    #region  Public member

    /// <summary>
    /// Items property
    /// </summary>
    public IEnumerable<AccountPublications> Items
    {
        get => GetValue(ItemsProperty) as IEnumerable<AccountPublications> ?? [];
        set => SetValue(ItemsProperty, value);
    }

    public Color BorderColor
    {
        get => GetValue(BorderColorProperty) as Color ?? Colors.MediumPurple;
        init => SetValue(BorderColorProperty, value);
    }

    #endregion
}