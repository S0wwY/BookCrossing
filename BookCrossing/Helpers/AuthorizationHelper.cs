using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookCrossing.Models;
using Microsoft.AspNetCore.Http;

namespace BookCrossing.Helpers
{
    public class AuthorizationHelper
    {
        public static bool TryGetAuthorizationTokenFromHttpHeaders(HttpContext httpContext, out string token)
        {
            token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);

            if (string.IsNullOrEmpty(token) || token == "null")
            {
                return false;
            }

            return true;
        }
    }
}
