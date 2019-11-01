using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Empresas.v1;

namespace WebApi.Interface.Infraestrutura.Empresas.v1
{
    public interface IEmpresaRepositorio
    {
        Empresa BuscarPeloId(int id);
        Empresa BuscarPeloCnpjUfNome(string cnpj, string uf, string nome);
        Empresa BuscarPeloCnpj(string cnpj);
        void Salvar(Empresa empresa);
        void Deletar(Empresa empresa);
    }
}
