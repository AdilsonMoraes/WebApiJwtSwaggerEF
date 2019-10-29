using System;
using System.Collections.Generic;
using System.Text;
using WebApi.infraestrutura.Contextos.v1;
using WebApi.Interface.Infraestrutura.InterfaceGenerica.v1;

namespace WebApi.infraestrutura.InterfaceGenerica.v1.Repositorio
{
    public class CrudRepositorio<TEntity> : ConsultaRepositorio<TEntity>,
         ICrudRepositorio<TEntity> where TEntity : class
    {
        protected readonly ContextoSql contexto;

        public CrudRepositorio(ContextoSql contexto) : base(contexto)
        {
            this.contexto = contexto;
        }

        public virtual void Altera(TEntity item)
        {
            contexto.Set<TEntity>().Attach(item);
            contexto.SaveChanges();
        }

        public virtual void Cadastra(TEntity item)
        {
            contexto.Set<TEntity>().Add(item);
            contexto.SaveChanges();
        }

        public virtual void Deleta(TEntity item)
        {
            contexto.Set<TEntity>().Remove(item);
            contexto.SaveChanges();
        }
    }
}
