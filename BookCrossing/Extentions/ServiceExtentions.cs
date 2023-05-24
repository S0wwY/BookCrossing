using BookCrossing.Data.Interfaces;
using BookCrossing.Data.UserContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Extentions
{
    public static class ServiceExtentions
    {
        public static void AddUserContext(this IServiceCollection services)
        {
            services.AddScoped<IUserContext, UserContext>();
        }
    }
}
