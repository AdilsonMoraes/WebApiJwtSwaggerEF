using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.Dominio.Erro.v1;
using WebApi.Dominio.Login.v1;
using WebApi.Dominio.Mensagens.v1;
using WebApi.Dominio.Mensagens.v1.Enum;
using WebApi.DTO.Login.v1;
using WebApi.Interface.Servico.Jwt;
using WebApi.Interface.Servico.Login.v1;

namespace WebApiCliente.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AutenticarController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AutenticarController(IJwtService jwtService)
        {
            _jwtService = jwtService;

        }

        [Route("GerarToken")]
        [HttpPost]
        public IActionResult Post([FromBody]LoginDTO login)
        {
            var resposta = new MensagemResposta();

            if (ModelState.IsValid)
            {
                try
                {
                    var token = _jwtService.CriaJsonWebToken(login);
                    return Ok(token);
                }
                catch (ErroException e)
                {
                    MontaRespostaErro(ref resposta, e);
                    return BadRequest(resposta);
                }
                catch (Exception e)
                {
                    MontaRespostaErroInesperado(ref resposta, e);
                    return BadRequest(resposta);
                }
            }

            return BadRequest("JSON inválido.");
        }

        private static void MontaRespostaErro(ref MensagemResposta resposta, ErroException e)
        {
            resposta.Dados = "null";
            resposta.Status = MensagemRespostaStatus.Erro;
            resposta.Erros = new List<Erro> { new Erro() { Codigo = e.Codigo, Descricao = e.Descricao } };
        }

        private static void MontaRespostaErroInesperado(ref MensagemResposta resposta, Exception e)
        {
            resposta.Dados = "null";
            resposta.Status = MensagemRespostaStatus.Sucesso;
            resposta.Erros = new List<Erro> { new Erro() { Codigo = "99", Descricao = $"{e.Message} - Favor entrar em contato com o time técnico." } };
        }



    }
}