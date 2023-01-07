using System.Reflection;
using BookingEksamenMAUI.Helpers.Artist;
using BookingEksamenMAUI.Helpers.Booker;
using BookingEksamenMAUI.Helpers.Comments;
using BookingEksamenMAUI.ViewModels;
using BookingEksamenMAUI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("BookingEksamenMAUI.appsettings.json");
            var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
            builder.Configuration.AddConfiguration(config);
            //builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            builder.Services.AddSingleton<ICommentAPIHelper, CommentAPIHelper>();
            builder.Services.AddSingleton<IBookerAPIHelper, BookerAPIHelper>();
            builder.Services.AddSingleton<IArtistAPIHelper, ArtistAPIHelper>();
            builder.Services.AddTransient<CommentsPage>();
            builder.Services.AddTransient<CommentViewModel>();

            return builder.Build();
        }
    }
}