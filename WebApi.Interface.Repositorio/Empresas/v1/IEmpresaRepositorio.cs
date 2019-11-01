using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Empresas.v1;

namespace WebApi.Interface.Infraestrutura.Empresas.v1
{
    public interface IEmpresaRepositorio
    {
        Empresa GetByID(int id);
        Empresa GetAll();
        void Save(Empresa empresa);
        void Delete(int Id);
    }
}
