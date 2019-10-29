using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Jwt.v1;
using WebApi.Dominio.Login.v1;

namespace WebApi.Interface.Servico.Jwt
{
    public interface IJwtService
    {
        JwtTokenSettings Settings { get; }
        string CriaJsonWebToken(UsuarioLogin user);
    }
}
