using Microsoft.Maui;
using Microsoft.Maui.Hosting;                        /* Progress bar */
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Controls.Xaml;

using Microsoft.Extensions.Logging;

using Syncfusion.Maui.Core.Hosting; //For PDF Viewer and circular progress bar
using CommunityToolkit.Maui;

namespace MAUIpractice
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureSyncfusionCore() //For PDF Viewer and progress bar
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("AirportIcons.ttf", "AirportIcons");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}