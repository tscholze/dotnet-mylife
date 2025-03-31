using MyLife.Core.Models.ContentCreation;
using CommunityToolkit.Maui.Markup;
using Platform = MyLife.Core.Models.Shared.Platform;

namespace MyLife.Maui.Controls;

/// <summary>
/// A component to display a list of publications in a horizontal scroll view.
/// </summary>
public partial class HorizontalPublicationsSection : VerticalStackLayout
{
    #region Constants

    /// <summary>
    /// Border color for even-indexed items.
    /// </summary>
    private static readonly Color EvenBorderColor = Colors.MediumPurple;

    /// <summary>
    /// Border color for odd-indexed items.
    /// </summary>
    private static readonly Color OddBorderColor = Colors.MediumAquamarine;

    /// <summary>
    /// Border radius for even-indexed items.
    /// </summary>
    private static readonly CornerRadius EvenBorderRadius = new(24, 6, 6, 24);

    /// <summary>
    /// Border radius for odd-indexed items.
    /// </summary>
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

    #region Private helper

    /// <summary>
    /// Calculate the border color of the list item based on the index.
    /// </summary>
    /// <param name="accountPublications">Underlying APs</param>
    /// <param name="index">Current index in list</param>
    /// <returns>Calculated border color of list item</returns>
    private static Color CalculateItemBorderColor(AccountPublications accountPublications, int index)
    {
        if (accountPublications.Account.Platform == Platform.Kotlog)
        {
            return Colors.Transparent;
        }

        return index % 2 == 0 ? EvenBorderColor : OddBorderColor;
    }

    /// <summary>
    /// Calculate the border radius of the list item based on the index.
    /// </summary>
    /// <param name="accountPublications">Underlying APs</param>
    /// <param name="index">Current index in list</param>
    /// <returns>Calculated border radius of list item</returns>
    private static CornerRadius CalculateItemBorderRadius(AccountPublications accountPublications, int index)
    {
        return index % 2 == 0 ? EvenBorderRadius : OddBorderRadius;
    }

    #endregion

    #region Events

    /// <summary>
    /// Handles changes for the "Items" property.
    /// </summary>
    /// <param name="bindable">Bindable HorizontalPublicationsSection control</param>
    /// <param name="oldValue">Unused old value</param>
    /// <param name="newValue">New value</param>
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
                var item = new HorizontalPublicationsSectionItemData(
                        publication.ImageUrl,
                        publication.Url,
                        CalculateItemBorderColor(accountPublication, index),
                        CalculateItemBorderRadius(accountPublication, index)
                    );

                index++;
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

/// <summary>
/// Data object representing a section in the horizontal publications view.
/// </summary>
/// <param name="Title">The title of the section.</param>
/// <param name="Platform">The platform type of the section.</param>
/// <param name="Items">Collection of publication items.</param>
internal record HorizontalPublicationsSectionData(
    string Title,
    Platform Platform,
    IEnumerable<HorizontalPublicationsSectionItemData> Items);

/// <summary>
/// Data object representing an individual publication item.
/// </summary>
/// <param name="ImageUrl">The URL of the publication's image.</param>
/// <param name="TargetUrl">The target URL when the item is selected.</param>
/// <param name="BorderColor">The color of the item's border.</param>
/// <param name="BorderRadius">The border radius of the item.</param>
internal record HorizontalPublicationsSectionItemData(
    string ImageUrl,
    string TargetUrl,
    Color BorderColor,
    CornerRadius BorderRadius
);