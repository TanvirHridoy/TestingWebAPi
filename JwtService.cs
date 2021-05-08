using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWebAPi
{
    public static class JwtService
    {
        private const string SecretKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJDb25xdWVyIiwibmFtZSI6IkRlbG93ZXIgQU1EIiwiaWF0IjoxNjIwNTI0NTA2fQ.zQy0AD-zr9xcQwEoOTNrfA8cKTGUjL1G58jzihydXW8";
        public static readonly SymmetricSecurityKey SIGNEDKEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        public static string GenerateJwtToken()
        {
            var credentials = new SigningCredentials(SIGNEDKEY, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(credentials);
            //Token will be expired after 20min
            DateTime Expire = DateTime.Now.AddMinutes(3);
            int ts = (int)(Expire - new DateTime(1970, 1, 1)).TotalSeconds;
            var payload = new JwtPayload()
            {
                { "sub","Test subject"},
                { "Name","Hridoy"},
                { "email","hridoy@asit.com.bd"},
                { "exp",ts},
                {"iss","http://localhost:5870"},
                {"aud","http://localhost:5870"}
            };
            //var payload = new JwtPayload()
            //{
            //    { "sub","Test subject"},
            //    { "Name","Hridoy"},
            //    { "email","hridoy@asit.com.bd"},
            //    { "exp",ts},
            //    {"iss","http://erp1.bepza.gov.bd:84"},
            //    {"aud","http://erp1.bepza.gov.bd:84"}
            //};
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();

            string tokenString = handler.WriteToken(secToken);
            return tokenString;
        }
    }
}
