using MauiIcons.Material;
using Microsoft.Extensions.Logging;
using MyLife.Core.Services;
using MyLife.Maui.ViewModels;

namespace MyLife.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
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


            builder.Services.AddTransient<LifeService>();
            builder.Services.AddTransient<MediumService>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
