using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApi.Dominio.Login.v1;
using WebApi.infraestrutura.Contextos.v1;
using WebApi.infraestrutura.InterfaceGenerica.v1.Repositorio;
using WebApi.Interface.Infraestrutura.Login.v1;

namespace WebApi.infraestrutura.Login.v1.Repositorio
{
    public class UsuarioLoginRepositorio : CrudRepositorio<UsuarioLogin>, IUsuarioLoginRepositorio
    {
        private readonly ContextoSql _contexto;

        public UsuarioLoginRepositorio(ContextoSql contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public UsuarioLogin Retorna(string login, string senha)
        {
            return _contexto.Logins
                .Where(l => l.Senha.Equals(senha)
                       && l.Usuario.Equals(login)
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

        public void Cadastra(UsuarioLogin login)
        {
            base.Cadastra(login);
        }

        public bool AlteraSenhaDo(UsuarioLogin login)
        {
            _contexto.Update(login);
            return _contexto.SaveChanges() > 0;
        }
    }
}
