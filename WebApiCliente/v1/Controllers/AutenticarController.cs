using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.Dominio.Login.v1;
using WebApi.Dominio.Mensagens.v1;
using WebApi.Interface.Servico.Jwt;
using WebApi.Interface.Servico.Login.v1;

namespace WebApiCliente.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutenticarController : ControllerBase
    {
        private readonly IJwtService jwtService;
        private readonly IUsuarioLoginServico usuarioLoginServico;

        public AutenticarController(IJwtService jwtService,
                                    IUsuarioLoginServico usuarioLoginServico)
        {
            this.jwtService = jwtService;
            this.usuarioLoginServico = usuarioLoginServico;
        }

        [HttpPost(Name = "GerarToken")]
        public IActionResult Post([FromBody]UsuarioLogin login)
        {
            UsuarioLogin usuario = usuarioLoginServico.Retorna(login);

            if (usuario != default(UsuarioLogin))
            {
                var token = jwtService.CriaJsonWebToken(usuario);
                return Ok(token);
            }

            return BadRequest(new List<ErroException>() { new ErroException("2", "Usuário inválido") });
        }
    }
}