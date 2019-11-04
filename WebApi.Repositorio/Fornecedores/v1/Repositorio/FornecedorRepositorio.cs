using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Dominio.Fornecedores.v1;
using WebApi.infraestrutura.Contextos.v1;
using WebApi.infraestrutura.InterfaceGenerica.v1.Repositorio;
using WebApi.Interface.Infraestrutura.Fornecedores.v1;

namespace WebApi.infraestrutura.Fornecedores.v1.Repositorio
{
    public class FornecedorRepositorio : CrudRepositorio<Fornecedor>, IFornecedorRepositorio
    {
        private readonly ContextoSql _contexto;

        public FornecedorRepositorio(ContextoSql contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public Fornecedor BuscaPeloId(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Fornecedor> ConsultaFornecedorCustomizada(string stringSql)
        {
            return contexto.Fornecedores
                .FromSql(stringSql)
                .ToList();
        }

        public void Deletar(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Salvar(Fornecedor fornecedor)
        {
            throw new System.NotImplementedException();
        }
    }
}
