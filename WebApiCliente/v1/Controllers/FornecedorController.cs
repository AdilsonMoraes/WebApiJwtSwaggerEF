using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.Dominio.Erro.v1;
using WebApi.Dominio.Mensagens.v1;
using WebApi.Dominio.Mensagens.v1.Enum;

namespace WebApiCliente.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FornecedorController : ControllerBase
    {
        [Route("CadastrarFornecedor")]
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
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
