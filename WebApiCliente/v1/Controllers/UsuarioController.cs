using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dominio.Login.v1;
using WebApi.Dominio.Mensagens.v1;
using WebApi.Interface.Servico.Login.v1;

namespace WebApiCliente.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize(Policy = "ElevatedRights")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioLoginServico _usuarioLoginServico;

        public UsuarioController(IUsuarioLoginServico usuarioLoginServico)
        {
            _usuarioLoginServico = usuarioLoginServico;
        }

        [Route("CadastrarUsuario")]
        [HttpPost]
        public IActionResult Post([FromBody]UsuarioLogin login)
        {
            try
            {
                bool cadastrou = _usuarioLoginServico.Cadastra(login);
                if (cadastrou)
                {
                    return Ok();
                }

                return BadRequest(new List<ErroException>() { new ErroException("2", "Login já cadastrado.") });
            }
            catch (Exception e)
            {
                return BadRequest(new List<ErroException>() { new ErroException("2", e.Message) });
            }
        }

        [Route("AlterarSenha")]
        [HttpPut]
        public IActionResult Put([FromBody]UsuarioLogin login)
        {
            try
            {
                bool alterou = _usuarioLoginServico.AlteraSenhaDo(login);
                if (alterou)
                {
                    return Ok();
                }

                return BadRequest(new List<ErroException>() { new ErroException("2", "Houve um problema na hora de alterar a senha.") });
            }
            catch (Exception e)
            {
                return BadRequest(new List<ErroException>() { new ErroException("2", e.Message) });
            }
        }
    }
}