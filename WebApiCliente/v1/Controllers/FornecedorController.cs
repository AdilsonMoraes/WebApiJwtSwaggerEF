using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using WebApi.Dominio.Erro.v1;
using WebApi.Dominio.Fornecedores.v1;
using WebApi.Dominio.Mensagens.v1;
using WebApi.Dominio.Mensagens.v1.Enum;
using WebApi.DTO.Fornecedor.v1;
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

        [Route("ConsultaFornecedor")]
        [HttpGet]
        public IActionResult ConsultaFornecedor(ConsultaFornecedorDTO dadosConsultaFornecedor)
        {
            var resposta = new MensagemResposta();

            try
            {
                var ret = _fornecedorServico.ProcesarConsulta(dadosConsultaFornecedor);
                resposta.Dados = JsonConvert.SerializeObject(dadosConsultaFornecedor);
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

        [Route("CadastrarFornecedor")]
        [HttpGet]
        public IActionResult CadastrarFornecedor(FornecedorDTO dadosFornecedor)
        {
            var resposta = new MensagemResposta();

            try
            {
                _fornecedorServico.Salvar(dadosFornecedor);
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
