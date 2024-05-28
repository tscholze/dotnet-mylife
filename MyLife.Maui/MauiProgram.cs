using MauiIcons.Material;
using Microsoft.Extensions.Logging;
using MyLife.Core.Services;
using MyLife.Maui.ViewModels;

namespace MyLife.Maui
{
    public static class MauiProgram
    {
        #region Private members

        //
        // Change this URL to your own repository
        //
        private const string remoteUrl = "https://tscholze.github.io/dotnet-mylife/";

        #endregion

        #region App builder

        public static MauiApp CreateMauiApp()
        {
            // Create the app builder
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMaterialMauiIcons()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("NotoSerif-Regular.ttf", "NotoSerifRegular");
                    fonts.AddFont("NotoSerif-SemiBold.ttf", "NotoSerifSemibold");
                });

            // Register services
            var httpClient = new HttpClient { BaseAddress = new Uri(remoteUrl) };
            builder.Services.AddSingleton(httpClient);
            builder.Services.AddTransient<LifeService>();
            builder.Services.AddTransient<MediumService>();

            // Register view models
            builder.Services.AddSingleton<MainViewModel>();

            // Register pages
            builder.Services.AddSingleton<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        #endregion
    }
}
