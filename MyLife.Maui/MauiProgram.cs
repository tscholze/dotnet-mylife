using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Markup;
using MauiIcons.Material;
using Microsoft.Extensions.Logging;
using MyLife.Core.Services;
using MyLife.Maui.Pages;
using MyLife.Maui.ViewModels;

namespace MyLife.Maui
{
    /// <summary>
    /// Entry point for the Maui app.
    /// </summary>
    public static class MauiProgram
    {
        #region Private members

        //
        // Change this URL to your own repository
        //
        private const string RemoteUrl = "https://tscholze.github.io/dotnet-mylife/";

        #endregion

        #region App builder

        public static MauiApp CreateMauiApp()
        {
            // Create the app builder
            var builder = MauiApp.CreateBuilder();

            // Configure the builder
            builder
                // Add MAUI features
                .UseMauiApp<App>()
                // Add MAUI Community Toolkit
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMarkup()
                // Add Material Icons
                .UseMaterialMauiIcons()
                // Add fFont Assets
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("NotoSerif-Regular.ttf", "NotoSerifRegular");
                    fonts.AddFont("NotoSerif-SemiBold.ttf", "NotoSerifSemibold");
                });

            // Register services
            var httpClient = new HttpClient { BaseAddress = new Uri(RemoteUrl) };
            builder.Services.AddSingleton(httpClient);
            builder.Services.AddTransient<LifeService>();

            // Register view models
            builder.Services.AddSingleton<WelcomeViewModel>();

            // Register pages
            builder.Services.AddSingleton<WelcomePage>();

            // Add debug only functionality
#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Build the builder!
            return builder.Build();
        }

        #endregion
    }
}
