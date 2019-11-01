using System;
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

        public Fornecedor BuscaPeloNomeCnpjData(string nome, string cnpj, DateTime dataCadastro)
        {
            return _contexto.Fornecedores.Where(w => w.Nome.Equals(nome)
            && w.CpfCnpjFornecedor.Equals(cnpj)
            && w.DtCadastro == dataCadastro).FirstOrDefault();
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
