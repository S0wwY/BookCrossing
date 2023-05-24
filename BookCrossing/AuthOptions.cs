using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthService"; // издатель токена
        public const string AUDIENCE = "BookCrossingClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123moreandmoreandmore";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

    }
}
