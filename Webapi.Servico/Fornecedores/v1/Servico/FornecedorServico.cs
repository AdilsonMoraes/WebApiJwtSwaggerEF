using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Fornecedores.v1;
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

        public Fornecedor BuscaFornecedorPeloNomeCnpjData(string nome, string cnpj, string dataCadastro)
        {
            DateTime data = new DateTime();
            var ret = _fornecedorRepositorio.BuscaPeloNomeCnpjData(nome, cnpj, data);
            return ret;
        }
    }
}
