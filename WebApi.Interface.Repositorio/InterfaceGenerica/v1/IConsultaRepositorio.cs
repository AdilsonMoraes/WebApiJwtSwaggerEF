using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Interface.Infraestrutura.InterfaceGenerica.v1
{
    public interface IConsultaRepositorio<TEntity> where TEntity : class
    {
        TEntity ObterPorId(object id);
    }
}

