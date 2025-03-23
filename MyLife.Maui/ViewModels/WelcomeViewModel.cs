using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyLife.Core.Models.ContentCreation;
using MyLife.Core.Services;
using Platform = MyLife.Core.Models.Shared.Platform;

namespace MyLife.Maui.ViewModels;

/// <summary>
/// ViewModel for the welcome also known as dashboard page.
/// </summary>
/// <param name="lifeService">Required life service</param>
public partial class WelcomeViewModel(LifeService lifeService) : ObservableObject
{
    #region Observable properties

    /// <summary>
    /// Firstname of the persona.
    /// </summary>
    [ObservableProperty] private string? firstname;

    /// <summary>
    /// Tagline of the persona.
    /// </summary>
    [ObservableProperty] private string? subtitle;

    /// <summary>
    /// URI to the avatar image.
    /// </summary>
    [ObservableProperty] private Uri? avatarImageUri;

    /// <summary>
    /// Headline for introduction.
    /// </summary>
    [ObservableProperty] private string? introductionHeadline;

    /// <summary>
    /// Introduction to the app of the persona
    /// </summary>
    [ObservableProperty] private string? shortIntroduction;

    [ObservableProperty] private IEnumerable<AccountPublications>? contentCreations;

    #endregion

    #region Commands

    /// <summary>
    /// Fetches the data from the services to render the dashboard.
    /// </summary>
    /// <returns>Awaitable task</returns>
    [RelayCommand]
    private async Task FetchData()
    {
        var life = await lifeService.GetLife();
        if (life is null) return;

        // Filter content creations
        ContentCreations = (await lifeService.GetContentPublications() ?? []).Where(cc =>
            cc.Account.Platform is Platform.Youtube or Platform.Medium or Platform.Kotlog);

        // Populate life
        Firstname = "Hi, I'm " + life.Persona.Firstname;
        Subtitle = string.Join(" / ", life.Persona.Nicknames) + " and Human Being from Bavaria";
        AvatarImageUri = new Uri(life.Persona.AvatarImageUrls[1]);
        IntroductionHeadline = life.Persona.IntroductionParagraphs.First();
        ShortIntroduction = life.Persona.IntroductionParagraphs.Skip(1).First();
    }

    #endregion
}