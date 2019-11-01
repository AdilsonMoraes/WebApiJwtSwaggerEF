using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.Dominio.Empresas.v1;
using WebApi.Dominio.Erro.v1;
using WebApi.Dominio.Mensagens.v1;
using WebApi.Dominio.Mensagens.v1.Enum;
using WebApi.DTO.Empresa.v1;
using WebApi.Interface.Servico.Empresa.v1;
using WebApi.Interface.Servico.ErroMapper.v1;

namespace WebApiCliente.v1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class EmpresaController : ControllerBase
    {

        private readonly IEmpresaServico _empresaServico;
        private readonly IErrosMapperServico _errosMapper;


        public EmpresaController(IEmpresaServico empresaServico,
            IErrosMapperServico errosMapper)
        {
            _empresaServico = empresaServico;
            _errosMapper = errosMapper;
        }


        [Route("CadastrarEmpresa")]
        [HttpPost]
        public IActionResult Post([FromBody]EmpresaDTO empresa)
        {
            if (ModelState.IsValid)
            {
                var resposta = new MensagemResposta();

                try
                {
                    var dadosEmpresa = new Empresa()
                    {
                        NomeFantasia = empresa.NomeFantasia,
                        Cnpj = empresa.Cnpj,
                        Uf = empresa.Uf
                    };

                    _empresaServico.Salvar(dadosEmpresa);
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

        [Route("DeletarEmpresa")]
        [HttpPost]
        public IActionResult DeletarEmpresa([FromBody]EmpresaDTO empresa)
        {
            if (ModelState.IsValid)
            {
                var resposta = new MensagemResposta();

                try
                {
                    _empresaServico.Deletar(empresa.Cnpj, empresa.Uf, empresa.NomeFantasia);
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


        [Route("BuscaEmpresa")]
        [HttpGet]
        public IActionResult BuscaEmpresa(string cnpj, string uf, string nome)
        {
            var resposta = new MensagemResposta();

            try
            {
                _empresaServico.BuscarPeloCnpjUfNome(cnpj, uf, nome);
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
