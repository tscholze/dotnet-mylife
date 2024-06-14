using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyLife.Core.Services;

namespace MyLife.Maui.ViewModels
{
    /// <summary>
    /// ViewModel for the main also known as Dashboard page.
    /// </summary>
    /// <param name="lifeService">Required life service</param>
    public partial class MainViewModel(LifeService lifeService) : ObservableObject
    {
        #region Observable properties

        /// <summary>
        /// Firstname of the persona.
        /// </summary>
        [ObservableProperty]
        private string? firstname;

        /// <summary>
        /// URI to the avatar image.
        /// </summary>
        [ObservableProperty]
        private Uri? avatarImageUri;

        /// <summary>
        /// Introducation to the app of the persona
        /// </summary>
        [ObservableProperty]
        private string? introduction;

        #endregion

        #region Commands

        /// <summary>
        /// Fetches the data from the services to render the dashboard.
        /// </summary>
        /// <returns></returns>
        [RelayCommand]
        private async Task FetchData()
        {
            var life = await lifeService.GetLife();
            if (life is null) return;

            Firstname = "Hi, I'm " + life.Persona.Firstname;
            AvatarImageUri = new(life.Persona.AvatarImageUrls[0]);
            Introduction = string.Join("\n", life.Persona.IntroductionParagraphs);
        }

        #endregion
    }
}
