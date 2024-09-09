using Microsoft.Extensions.Logging;
using PascalBoard.ExternClasses;
using Plugin.Maui.Audio;

namespace PascalBoard
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // DataStorage Registered
            builder.Services.AddSingleton<DataStorage>();
            builder.Services.AddSingleton(AudioManager.Current);


            // Registered Transmition
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<VibrationPage>();
            builder.Services.AddTransient<BarPage>();


            return builder.Build();
        }
    }
}
