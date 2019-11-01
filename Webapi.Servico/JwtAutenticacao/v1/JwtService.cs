using log4net;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Dominio.Jwt.v1;
using WebApi.Dominio.Login.v1;
using WebApi.Dominio.Mensagens.v1;
using WebApi.DTO.Login.v1;
using WebApi.Enums.Exceptions.Login.v1;
using WebApi.Interface.Servico.Jwt;
using WebApi.Interface.Servico.Login.v1;

namespace Webapi.Servico.JwtAutenticacao.v1
{
    public class JwtService : IJwtService
    {

        private readonly IUsuarioLoginServico _usuarioLoginServico;

        public JwtService(IUsuarioLoginServico usuarioLoginServico,
            IOptions<JwtTokenSettings> settings)
        {
            this.Settings = settings?.Value;
            _usuarioLoginServico = usuarioLoginServico;
        }

        public JwtTokenSettings Settings { get; }

        public string CriaJsonWebToken(LoginDTO user)
        {
            var dadosUser = new UsuarioLogin()
            {
                Usuario = user.Usuario,
                Senha = user.Senha,
                IsAdministrator = user.IsAdministrator
            };

            var usuario = _usuarioLoginServico.Retorna(dadosUser);
            if (usuario == null)
            {
                throw new ErroException(LoginEnumException.USUARIO_INVALIDO.Codigo.ToString(),
                        LoginEnumException.USUARIO_INVALIDO.Valor);
            }

            var identity = GetClaimsIdentity(dadosUser);
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

            // if (user.IsAdministrator)
            //{
            //claims[0] = user.TokenAuth;
            //   claims[0] = TokenAutorizacaoPorClienteEnum.TOKEN_ADM.ToString();
            // }
            // else
            // {
            //   claims[0] = TokenAutorizacaoPorClienteEnum.TOKEN_DEFAULT.ToString();
            // }

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
