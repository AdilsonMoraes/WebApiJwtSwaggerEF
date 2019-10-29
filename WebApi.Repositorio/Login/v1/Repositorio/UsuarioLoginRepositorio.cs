using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Dominio.Login.v1;
using WebApi.infraestrutura.Contextos.v1;
using WebApi.Interface.Infraestrutura.Login.v1;

namespace WebApi.infraestrutura.Login.v1.Repositorio
{
    public class UsuarioLoginRepositorio : IUsuarioLoginRepositorio
    {
        private ContextoSql _contexto;

        public UsuarioLoginRepositorio(ContextoSql contexto)
        {
            _contexto = contexto;
        }

        public UsuarioLogin Retorna(UsuarioLogin login)
        {
            return _contexto.Logins
                .Where(l => l.Senha.Equals(login.Senha)
                       && l.Usuario.Equals(login.Usuario)
                       ).FirstOrDefault();
        }

        public UsuarioLogin RetornaLogin(string nomeUsuario)
        {
            return _contexto.Logins
                .Where(l => l.Usuario.Equals(nomeUsuario)
                       ).FirstOrDefault();
        }

        public bool LoginExistePara(string nomeUsuario)
        {
            return _contexto.Logins
                .Where(l => l.Usuario.Equals(nomeUsuario)
                       )
                .Count() > 0;
        }

        public bool Cadastra(UsuarioLogin login)
        {
            _contexto.Add(login);
            return _contexto.SaveChanges() > 0;
        }

        public bool AlteraSenhaDo(UsuarioLogin login)
        {
            _contexto.Update(login);
            return _contexto.SaveChanges() > 0;
        }
    }
}
