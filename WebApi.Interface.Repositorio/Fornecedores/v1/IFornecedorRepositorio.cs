using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Fornecedores.v1;

namespace WebApi.Interface.Infraestrutura.Fornecedores.v1
{
    public interface IFornecedorRepositorio
    {
        Fornecedor GetByID(int id);
        Fornecedor GetAll();
        void Save(Fornecedor fornecedor);
        void Delete(int Id);

        //Req01
        //A listagem de fornecedores deverá conter filtros por Nome, CPF/CNPJ e data de cadastro.
        Fornecedor GetByFornecedor(Fornecedor fornecedor);
    }
}
