using Microsoft.Extensions.Logging;
using SPJMauiApp.Services;
using System.IO;

namespace SPJMauiApp
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

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "CatalogoDatabase.db3");

            // Registrar el servicio de base de datos
            builder.Services.AddSingleton(new DatabaseService(dbPath));

            return builder.Build();


        }
    }
}
