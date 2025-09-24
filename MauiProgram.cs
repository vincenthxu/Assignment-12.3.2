using Assignment_12._3._2.Data;
using Assignment_12._3._2.Models;
using Assignment_12._3._2.Services;
using Assignment_12._3._2.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment_12._3._2
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
            builder.Services.AddSingleton<BookRetrievalService>();
            builder.Services.AddDbContext<BookContext>(
                options => options.UseSqlite("data source=book.db")
            );
            builder.Services.AddSingleton<BookViewModel>();
            builder.Services.AddSingleton<MainPage>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<BookContext>();
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                if(!db.Books.Any())
                {
                    db.Books.AddRange
                    (
                        new Book() { key = "123", author_name = ["Isaac Asimov"], title="Foundation"},
                        new Book() { key = "456", author_name = ["Isaac Asimov"], title="I Robot" }
                    );
                    db.SaveChanges();
                }
            }

            return app;
        }
    }
}
