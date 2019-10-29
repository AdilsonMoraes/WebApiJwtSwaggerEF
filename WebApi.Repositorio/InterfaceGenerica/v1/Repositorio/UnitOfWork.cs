using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.infraestrutura.Contextos.v1;
using WebApi.Interface.Infraestrutura.InterfaceGenerica.v1;

namespace WebApi.infraestrutura.InterfaceGenerica.v1.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextoSql contexto;

        public UnitOfWork(ContextoSql contexto)
        {
            this.contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public void ExecuteInTransaction(Func<bool> action)
        {
            var executionStrategy = contexto.Database.CreateExecutionStrategy();
            executionStrategy.Execute(() => {

                using (var transaction = contexto.Database.BeginTransaction())
                {
                    bool resultado = action();
                    if (resultado)
                        transaction.Commit();
                }
            });
        }
    }
}
