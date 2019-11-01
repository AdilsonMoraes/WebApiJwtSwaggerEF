using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dominio.Erro.v1;
using WebApi.Dominio.Login.v1;
using WebApi.Dominio.Mensagens.v1;
using WebApi.Dominio.Mensagens.v1.Enum;
using WebApi.DTO.Login.v1;
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
            var resposta = new MensagemResposta();
            try
            {
                _usuarioLoginServico.Cadastra(login);
                resposta.Dados = null;
                resposta.Status = MensagemRespostaStatus.Sucesso;
                return Ok(resposta);
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

        [Route("AlterarSenha")]
        [HttpPut]
        public IActionResult Put([FromBody]LoginDTO login)
        {
            var resposta = new MensagemResposta();

            if (ModelState.IsValid)
            {
                try
                {
                    _usuarioLoginServico.AlteraSenhaDo(login.Usuario, login.Senha);
                    resposta.Dados = null;
                    resposta.Status = MensagemRespostaStatus.Sucesso;
                    return Ok(resposta);
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