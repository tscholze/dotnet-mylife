using MauiIcons.Core;
using MyLife.Maui.ViewModels;

namespace MyLife.Maui.Pages;

public partial class WelcomePage : ContentPage
{
	public WelcomePage(WelcomeViewModel viewModel)
	{
		BindingContext = viewModel;
		viewModel.FetchDataCommand.Execute(null);

		InitializeComponent();
		
		// Temporary Workaround for url styled namespace in xaml
		_ = new MauiIcon();
	}
}
