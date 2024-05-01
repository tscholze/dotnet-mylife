using MauiIcons.Core;
using MyLife.Maui.ViewModels;

namespace MyLife.Maui
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel viewModel)
        {
            BindingContext = viewModel;
            viewModel.FetchDataCommand.Execute(null);

            InitializeComponent();
            // Temporary Workaround for url styled namespace in xaml
            _ = new MauiIcon();
        }
    }

}
