using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Login.v1;

namespace WebApi.Interface.Infraestrutura.Login.v1
{
    public interface IUsuarioLoginRepositorio
    {
        UsuarioLogin Retorna(string login, string senha);
        bool LoginExistePara(string nomeUsuario);
        void Cadastra(UsuarioLogin login);
        bool AlteraSenhaDo(UsuarioLogin login);
        UsuarioLogin RetornaLogin(string nomeUsuario);
    }
}
