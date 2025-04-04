using MauiIcons.Core;
using MyLife.Maui.ViewModels;

namespace MyLife.Maui.Pages;

/// <summary>
/// Welcome page that serves as the main entry point of the application.
/// </summary>
public partial class WelcomePage : ContentPage
{
    /// <summary>
    /// Initializes a new instance of the WelcomePage.
    /// </summary>
    /// <param name="viewModel">The view model to bind to this page.</param>
    public WelcomePage(WelcomeViewModel viewModel)
    {
        BindingContext = viewModel;
        viewModel.FetchDataCommand.Execute(null);

        InitializeComponent();
        
        // Temporary Workaround for url styled namespace in xaml
        _ = new MauiIcon();
    }
}
