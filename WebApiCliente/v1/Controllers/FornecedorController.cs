using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.Dominio.Erro.v1;
using WebApi.Dominio.Mensagens.v1;
using WebApi.Dominio.Mensagens.v1.Enum;
using WebApi.Interface.Servico.ErroMapper.v1;
using WebApi.Interface.Servico.Fornecedor.v1;

namespace WebApiCliente.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorServico _fornecedorServico;
        private readonly IErrosMapperServico _errosMapper;

        public FornecedorController(IFornecedorServico fornecedorServico,
            IErrosMapperServico errosMapper)
        {
            _fornecedorServico = fornecedorServico;
            _errosMapper = errosMapper;
        }

        [Route("CadastrarFornecedor")]
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [Route("BuscaFornecedor")]
        [HttpGet]
        public IActionResult BuscaFornecedor(string nome, string cnpj, string dataCadastro)
        {
            var resposta = new MensagemResposta();

            try
            {
                _fornecedorServico.BuscaFornecedorPeloNomeCnpjData(nome, cnpj, dataCadastro);
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
