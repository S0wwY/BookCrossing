using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Application.Interfaces;
using BookCrossing.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookCrossing.Application.Configurations
{
    public static class ServicesConfiguration
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
        }
    }
}
