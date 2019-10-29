using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Dominio.Jwt.v1
{
    public class JwtTokenSettings
    {
        public string Audience { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string IssuerSigningKey { get; set; } = string.Empty;
        public int ExpirationInMinutes { get; set; }
        public SigningCredentials SigningCredentials { get; }
    }
}
