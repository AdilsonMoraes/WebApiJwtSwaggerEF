using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Interface.Infraestrutura.InterfaceGenerica.v1
{
    public interface IUnitOfWork
    {
        void ExecuteInTransaction(Func<bool> action);
    }
}
