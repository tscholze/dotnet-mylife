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

    #endregion
}