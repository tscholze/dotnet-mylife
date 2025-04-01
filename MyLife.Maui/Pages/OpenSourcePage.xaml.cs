using MauiIcons.Core;
using MauiIcons.Material;
using MyLife.Maui.ViewModels;

namespace MyLife.Maui.Pages;

/// <summary>
/// Content page that displays open source related information.
/// </summary>
public partial class OpenSourcePage : ContentPage
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OpenSourcePage"/> class.
    /// </summary>
    /// <param name="viewModel">View model that handles the business logic.</param>
    public OpenSourcePage(OpenSourceViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        
        // Trigger initial data load
        viewModel.FetchDataCommand.Execute(null);
    }
}