using BookCrossing.Helpers;
using System.IdentityModel.Tokens.Jwt;
using BookCrossing.Data.Interfaces;
using BookCrossing.Data.UserContext;
using System.Security.Principal;

namespace BookCrossing.Middleware
{
    public class ConfigureUserContextMiddleware
    {
        private readonly RequestDelegate _next;

        public ConfigureUserContextMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IUserContext clientUserContext)
        {
            if (AuthorizationHelper.TryGetAuthorizationTokenFromHttpHeaders(httpContext, out string token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                //var jsonToken = handler.ReadJwtToken(token);
                var tokenS = jsonToken as JwtSecurityToken;

                //var tokenS = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(token);

                clientUserContext.Name = tokenS.Claims?.FirstOrDefault(x => x.Type.Equals("name", StringComparison.OrdinalIgnoreCase))?.Value;
                clientUserContext.Email = tokenS.Claims?.FirstOrDefault(x => x.Type.Equals("email", StringComparison.OrdinalIgnoreCase))?.Value;
                clientUserContext.UserId = Guid.Parse(tokenS.Claims?.FirstOrDefault(x => x.Type.Equals("id", StringComparison.OrdinalIgnoreCase))?.Value);
            }

            await _next.Invoke(httpContext);
        }
    }
}
