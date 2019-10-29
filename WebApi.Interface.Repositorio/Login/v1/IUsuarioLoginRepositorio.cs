using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Login.v1;

namespace WebApi.Interface.Infraestrutura.Login.v1
{
    public interface IUsuarioLoginRepositorio
    {
        UsuarioLogin Retorna(UsuarioLogin login);
        bool LoginExistePara(string nomeUsuario);
        bool Cadastra(UsuarioLogin login);
        bool AlteraSenhaDo(UsuarioLogin login);
        UsuarioLogin RetornaLogin(string nomeUsuario);
    }
}
