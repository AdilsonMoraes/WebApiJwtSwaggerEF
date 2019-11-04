using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Fornecedores.v1;
using WebApi.Dominio.Mensagens.v1;
using WebApi.DTO.Fornecedor.v1;
using WebApi.Enums.Exceptions.Fornecedor.v1;
using WebApi.Interface.Infraestrutura.Fornecedores.v1;
using WebApi.Interface.Servico.Fornecedor.v1;

namespace Webapi.Servico.Fornecedores.v1.Servico
{
    public class FornecedorServico : IFornecedorServico
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;


        public FornecedorServico(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        public List<Fornecedor> ProcesarConsulta(ConsultaFornecedorDTO dadosConsultaFornecedor)
        {
            ValidaParametros(dadosConsultaFornecedor);
            var stringSql = MontaQuery(dadosConsultaFornecedor);
            return _fornecedorRepositorio.ConsultaFornecedorCustomizada(stringSql);
        }

        public void Salvar(FornecedorDTO dadosFornecedor)
        {
            throw new NotImplementedException();
        }

        private string MontaQuery(ConsultaFornecedorDTO dadosConsultaFornecedor)
        {
            var stringSql = "SELECT * FROM fornecedor WHERE 1 = 1 ";
            var stringSqlWhere = string.Empty;

            if (!string.IsNullOrEmpty(dadosConsultaFornecedor.CpfCnpjFornecedor) || !string.IsNullOrWhiteSpace(dadosConsultaFornecedor.CpfCnpjFornecedor)) {
                stringSqlWhere = $"{stringSqlWhere} AND cnpj = {dadosConsultaFornecedor.CpfCnpjFornecedor}";
            }

            if (!string.IsNullOrEmpty(dadosConsultaFornecedor.Nome) || !string.IsNullOrWhiteSpace(dadosConsultaFornecedor.Nome))
            {
                stringSqlWhere = $"{stringSqlWhere} AND nome = {dadosConsultaFornecedor.Nome}";
            }

            if (!string.IsNullOrEmpty(dadosConsultaFornecedor.DtCadastro) || !string.IsNullOrWhiteSpace(dadosConsultaFornecedor.DtCadastro))
            {
                stringSqlWhere = $"{stringSqlWhere} AND dt_cadastro = '{dadosConsultaFornecedor.DtCadastro}'";
            }

            return $"{stringSql}{stringSqlWhere}";
        }

        private void ValidaParametros(ConsultaFornecedorDTO dadosConsultaFornecedor)
        {
            if((string.IsNullOrEmpty(dadosConsultaFornecedor.CpfCnpjFornecedor) || string.IsNullOrWhiteSpace(dadosConsultaFornecedor.CpfCnpjFornecedor)) 
                || (string.IsNullOrEmpty(dadosConsultaFornecedor.Nome) || string.IsNullOrWhiteSpace(dadosConsultaFornecedor.Nome))
                ||(string.IsNullOrEmpty(dadosConsultaFornecedor.DtCadastro) || string.IsNullOrWhiteSpace(dadosConsultaFornecedor.DtCadastro))){

                throw new ErroException(FornecedorEnumException.DADOS_NAO_INFORMADO.Codigo.ToString(),
                    FornecedorEnumException.DADOS_NAO_INFORMADO.Valor);
            }

        }

    }
}
