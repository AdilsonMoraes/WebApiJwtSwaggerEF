using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Fornecedores.v1;

namespace WebApi.Interface.Infraestrutura.Fornecedores.v1
{
    public interface IFornecedorRepositorio
    {
        Fornecedor BuscaPeloId(int id);
        Fornecedor BuscaTodos();
        void Salvar(Fornecedor fornecedor);
        void Deletar(int Id);

        //Req01
        //A listagem de fornecedores deverá conter filtros por Nome, CPF/CNPJ e data de cadastro.
        Fornecedor RetornarFornecedor(Fornecedor fornecedor);
    }
}
