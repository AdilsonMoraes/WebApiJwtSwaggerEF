using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Login.v1;

namespace WebApi.Interface.Servico.Login.v1
{
    public interface IUsuarioLoginServico
    {
        UsuarioLogin Retorna(UsuarioLogin login);
        UsuarioLogin RetornaLogin(string login);
        bool Cadastra(UsuarioLogin login);
        bool AlteraSenhaDo(UsuarioLogin login);
    }
}
