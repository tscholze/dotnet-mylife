﻿using CommunityToolkit.Maui;
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

                // Add MAUI Community Toolkit helpers
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
      
                // Add experimental features
#if IOS
                builder.ConfigureMauiHandlers(handlers =>
                {
                    handlers.AddHandler<Microsoft.Maui.Controls.CollectionView, Microsoft.Maui.Controls.Handlers.Items2.CollectionViewHandler2>();
                    handlers.AddHandler<Microsoft.Maui.Controls.CarouselView, Microsoft.Maui.Controls.Handlers.Items2.CarouselViewHandler2>();
                });
#endif

            // Register services
            var httpClient = new HttpClient { BaseAddress = new Uri(RemoteUrl) };
            builder.Services.AddSingleton(httpClient);
            builder.Services.AddTransient<LifeService>();

            // Register view models
            builder.Services.AddSingleton<WelcomeViewModel>();
            builder.Services.AddSingleton<OpenSourceViewModel>();

            // Register pages
            builder.Services.AddSingleton<WelcomePage>();
            builder.Services.AddSingleton<OpenSourcePage>();

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
