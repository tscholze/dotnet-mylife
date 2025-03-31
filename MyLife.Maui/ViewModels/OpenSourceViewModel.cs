using CommunityToolkit.Mvvm.ComponentModel;
using MyLife.Core.Services;
using CommunityToolkit.Mvvm.Input;
using MyLife.Core.Models.OpenSource;

namespace MyLife.Maui.ViewModels;

public partial class OpenSourceViewModel(LifeService lifeService) : ObservableObject
{
    #region Observable properties

    [ObservableProperty] private string motivation = string.Empty;

    [ObservableProperty] private string githubName = string.Empty;
    [ObservableProperty] private Uri githubUri = new("https://github.com");
    [ObservableProperty] private IEnumerable<ProjectFamily> projectFamilies = [];


    #endregion

    #region Commands

    [RelayCommand]
    private async Task OpenGitHub()
    {
        try
        {
            await Browser.OpenAsync(GithubUri, BrowserLaunchMode.External);
        }
        catch (Exception ex)
        {
            await Shell.Current.DisplayAlert("Error", $"Could not open URL. {ex.Message}", "OK");
        }
    }

    /// <summary>
    /// Fetches the data from the services to render the dashboard.
    /// </summary>
    /// <returns>Awaitable task</returns>
    [RelayCommand]
    private async Task FetchData()
    {
        var openSource = (await lifeService.GetLife())?.OpenSource;
        if (openSource is null) return;


        Motivation = openSource.Motivation;
        GithubName = openSource.GitHubUsername;
        GithubUri = openSource.GitHubUrl;
        ProjectFamilies = openSource.ProjectFamilies;
    }

    #endregion
}
