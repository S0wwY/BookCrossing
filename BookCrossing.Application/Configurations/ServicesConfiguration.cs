using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Application.Interfaces;
using BookCrossing.Application.Services;
using BookCrossing.Data.Interfaces;
using BookCrossing.Models;
using Microsoft.Extensions.DependencyInjection;

namespace BookCrossing.Application.Configurations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IShelfService, ShelfService>();
            services.AddTransient<IWriterService, WriterService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IBookShelfService, BookShelfService>();
            services.AddScoped<IEmailSenderService, EmailSenderService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
