using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Dominio.Autorizacoes.v1
{
    public interface IAutorizacao
    {
        string token_auth { get; set; }
    }
}
