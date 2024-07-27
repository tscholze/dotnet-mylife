using MyLife.Core.Models.ContentCreation;
using CommunityToolkit.Maui.Markup;

namespace MyLife.Maui.Controls;

/// <summary>
/// A component to display a list of publications in a horizontal scroll view.
/// </summary>
public partial class HorizontalPublicationsSection : VerticalStackLayout
{
    #region Constants

    private static readonly Color EvenBorderColor = Colors.MediumPurple;
    private static readonly Color OddBorderColor = Colors.MediumAquamarine;
    private static readonly CornerRadius EvenBorderRadius = new(24, 6, 6, 24);
    private static readonly CornerRadius OddBorderRadius = new(6, 24, 24, 6);

    #endregion

    #region BindableProperty

    /// <summary>
    /// Bindable Items property.
    /// </summary>
    public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
        "Items",
        typeof(IEnumerable<AccountPublications>),
        typeof(HorizontalPublicationsSection),
        propertyChanged: OnItemsPropertyChanged
    );

    #endregion

    #region Constructor

    public HorizontalPublicationsSection()
    {
        InitializeComponent();
    }

    #endregion

    #region Events

    private static void OnItemsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        // Ensure type-safety
        if (bindable is not HorizontalPublicationsSection control) return;
        if (newValue is not IEnumerable<AccountPublications> accountPublications) return;

        // Create list of sections
        var sections = new List<HorizontalPublicationsSectionData>();
        foreach (var accountPublication in accountPublications)
        {
            var index = 0;
            var items = new List<HorizontalPublicationsSectionItemData>();

            // Create items
            foreach (var publication in accountPublication.Publications)
            {
                // Not working: https://github.com/dotnet/maui/issues/21747 
                var isEven = index++ % 2 == 0;
                var item = new HorizontalPublicationsSectionItemData(
                    publication.ImageUrl,
                    publication.Url,
                    isEven ? EvenBorderColor : OddBorderColor,
                    isEven ? EvenBorderRadius : OddBorderRadius
                );

                items.Add(item);
            }

            // Create section from item
            var section = new HorizontalPublicationsSectionData(
                accountPublication.Account.Name,
                accountPublication.Account.Platform,
                items
            );

            sections.Add(section);
        }

        // Set item source
        control.ItemsSource(sections);
    }

    #endregion
}

internal record HorizontalPublicationsSectionData(
    string Title,
    MyLife.Core.Models.Shared.Platform Platform,
    IEnumerable<HorizontalPublicationsSectionItemData> Items);

internal record HorizontalPublicationsSectionItemData(
    string ImageUrl,
    string TargetUrl,
    Color BorderColor,
    CornerRadius BorderRadius
    );