using MyLife.Core.Models.ContentCreation;

namespace MyLife.Maui.Controls;

public partial class HorizontalPublicationsSection : VerticalStackLayout
{
    public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items),
        typeof(IEnumerable<AccountPublications>), typeof(HorizontalPublicationsSection));

    public HorizontalPublicationsSection()
    {
        InitializeComponent();
    }

    public IEnumerable<AccountPublications> Items
    {
        get => GetValue(ItemsProperty) as IEnumerable<AccountPublications> ?? [];
        set => SetValue(ItemsProperty, value);
    }
}