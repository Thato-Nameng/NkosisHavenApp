using Microsoft.Extensions.Logging;
using NkosisHavenApp.Data;

namespace NkosisHavenApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Set up the main app, fonts, and Blazor WebView
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Register services here
            builder.Services.AddSingleton<IDataStore, DataService>();
            builder.Services.AddSingleton<AppointmentDataService>(); 
            builder.Services.AddSingleton<DoctorDataService>();
            builder.Services.AddSingleton<MedicationDataService>();
            builder.Services.AddSingleton<DiagnosesDataService>();
            // Register Blazor WebView services
            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddBlazorWebViewDeveloperTools();
            
            // Configure logging to output to debug window
            builder.Logging.AddDebug();

            return builder.Build();
        }
    }
}
