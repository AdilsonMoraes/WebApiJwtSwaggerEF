using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Fornecedores.v1;

namespace WebApi.Interface.Infraestrutura.Fornecedores.v1
{
    public interface IFornecedorRepositorio
    {
        Fornecedor BuscaPeloId(int id);
        Fornecedor BuscaPeloNomeCnpjData(string nome, string cnpj, DateTime dataCadastro);
        void Salvar(Fornecedor fornecedor);
        void Deletar(int Id);
    }
}
