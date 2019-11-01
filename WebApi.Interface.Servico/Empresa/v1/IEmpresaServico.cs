
namespace WebApi.Interface.Servico.Empresa.v1
{
    public interface IEmpresaServico
    {
        void Salvar(Dominio.Empresas.v1.Empresa empresa);
        void Deletar(string cnpj, string uf, string nome);
        Dominio.Empresas.v1.Empresa BuscarPeloCnpjUfNome(string cnpj, string uf, string nome);
        Dominio.Empresas.v1.Empresa BuscarPeloCnpjUfNome(string cnpj);
    }
}
