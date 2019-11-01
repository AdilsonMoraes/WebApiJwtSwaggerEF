using System.Linq;
using WebApi.Dominio.Empresas.v1;
using WebApi.infraestrutura.Contextos.v1;
using WebApi.infraestrutura.InterfaceGenerica.v1.Repositorio;
using WebApi.Interface.Infraestrutura.Empresas.v1;

namespace WebApi.infraestrutura.Empresas.v1.Repositorio
{
    public class EmpresaRepositorio : CrudRepositorio<Empresa>, IEmpresaRepositorio
    {
        private readonly ContextoSql _contexto;

        public EmpresaRepositorio(ContextoSql contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public Empresa BuscarPeloId(int id)
        {
            return base.contexto.Empresas.Where(w => w.Id == id)
            .FirstOrDefault();
        }

        public Empresa BuscarPeloCnpjUfNome(string cnpj, string uf, string nome)
        {
            return base.contexto.Empresas.Where(w => w.NomeFantasia.Contains(nome)
            && w.Uf.Contains(uf)
            && w.Cnpj.Contains(cnpj))
            .FirstOrDefault();
        }

        public void Deletar(Empresa empresa)
        {
            base.Deleta(empresa);
        }

        public void Salvar(Empresa empresa)
        {
            base.Cadastra(empresa);
        }

        public Empresa BuscarPeloCnpj(string cnpj)
        {
            return _contexto.Empresas.Where(w => w.Cnpj.Contains(cnpj)).FirstOrDefault();
        }
    }
}
