using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Fornecedores.v1;

namespace WebApi.Interface.Infraestrutura.Fornecedores.v1
{
    public interface IFornecedorRepositorio
    {
        Fornecedor BuscaPeloId(int id);
        List<Fornecedor> ConsultaFornecedorCustomizada(string querySql);
        void Salvar(Fornecedor fornecedor);
        void Deletar(int Id);
    }
}
