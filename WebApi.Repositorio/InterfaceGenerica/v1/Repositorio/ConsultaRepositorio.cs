using System;
using System.Collections.Generic;
using System.Text;
using WebApi.infraestrutura.Contextos.v1;
using WebApi.Interface.Infraestrutura.InterfaceGenerica.v1;

namespace WebApi.infraestrutura.InterfaceGenerica.v1.Repositorio
{
    public class ConsultaRepositorio<TEntity> : IConsultaRepositorio<TEntity> where TEntity : class
    {
        private readonly ContextoSql _contextoSql;

        public ConsultaRepositorio(ContextoSql contextoSql)
        {
            _contextoSql = contextoSql;
        }

        public TEntity ObterPorId(object id)
        {
            return _contextoSql.Set<TEntity>()
                .Find(id);
        }
    }
}
