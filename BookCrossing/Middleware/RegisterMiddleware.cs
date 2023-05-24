
namespace BookCrossing.Middleware
{
    public static class RegisterMiddleware
    {
        public static void RegisterUserContextMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ConfigureUserContextMiddleware>();
        }
    }
}
