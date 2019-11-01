using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Interface.Servico.Fornecedor.v1
{
    public interface IFornecedorServico
    {
        Dominio.Fornecedores.v1.Fornecedor BuscaFornecedorPeloNomeCnpjData(string nome, string cnpj, string dataCadastro);
    }
}
