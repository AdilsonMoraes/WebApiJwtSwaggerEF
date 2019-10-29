using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Dominio.Jwt.v1;
using WebApi.Dominio.Login.v1;
using WebApi.Interface.Servico.Jwt;

namespace Webapi.Servico.JwtAutenticacao.v1
{
    public class JwtService : IJwtService
    {
        public JwtService(IOptions<JwtTokenSettings> settings)
        {
            this.Settings = settings?.Value;
        }

        public JwtTokenSettings Settings { get; }

        public string CriaJsonWebToken(UsuarioLogin user)
        {
            var identity = GetClaimsIdentity(user);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = identity,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(Settings.IssuerSigningKey)),
                        SecurityAlgorithms.HmacSha256),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now + TimeSpan.FromMinutes(Settings.ExpirationInMinutes),
            });

            return handler.WriteToken(securityToken);
        }

        private static ClaimsIdentity GetClaimsIdentity(UsuarioLogin user)
        {
            var identity = new ClaimsIdentity();
            var claimStringBuilder = new StringBuilder();
            var claims = new string[3];

            claims[0] = string.Empty;

            if (!string.IsNullOrWhiteSpace(user.TokenAuth))
            {
                claims[0] = user.TokenAuth;
            }

            claims[1] = user.Usuario;
            claims[2] = $"{DateTime.Now.Ticks.ToString().Substring(0, 5)}";

            if (user.IsAdministrator)
            {
                identity.AddClaim(new Claim("a", "1"));
            }

            var todasClaims = claimStringBuilder.AppendJoin("|", claims);
            identity.AddClaim(new Claim("t", todasClaims.ToString()));

            return identity;
        }

    }
}
