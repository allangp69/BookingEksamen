using BookingEksamenMAUI.Data;
using BookingEksamenMAUI.Helpers.Artist;
using BookingEksamenMAUI.Helpers.Booker;
using BookingEksamenMAUI.Helpers.Comments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace BookingEksamenMAUI
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
            
            var config = new ConfigurationBuilder()                        
                        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                        .Build();            

            builder.Configuration.AddConfiguration(config);

            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<ICommentAPIHelper, CommentAPIHelper>();
            builder.Services.AddSingleton<IBookerAPIHelper, BookerAPIHelper>();
            builder.Services.AddSingleton<IArtistAPIHelper, ArtistAPIHelper>();

            return builder.Build();
        }
    }
}