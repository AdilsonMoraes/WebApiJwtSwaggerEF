using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Webapi.Servico.Logins.v1.Validacao;
using WebApi.Dominio.Globalizacao.v1;
using WebApi.Dominio.Login.v1;
using WebApi.Interface.Infraestrutura.Login.v1;
using WebApi.Interface.Servico.Login.v1;

namespace Webapi.Servico.Logins.v1.Servico
{
    public class UsuarioLoginServico : IUsuarioLoginServico
    {

        private readonly IUsuarioLoginRepositorio _repositorio;
        private readonly IStringLocalizer<Textos> _globalizacao;

        public UsuarioLoginServico(IUsuarioLoginRepositorio repositorio,
                                    IStringLocalizer<Textos> globalizacao)
        {
            _repositorio = repositorio;
            _globalizacao = globalizacao;
        }

        public bool AlteraSenhaDo(UsuarioLogin login)
        {
            return _repositorio.AlteraSenhaDo(login);
        }

        public bool Cadastra(UsuarioLogin login)
        {
            if (!LoginExistePara(login.Usuario))
            {
                return _repositorio.Cadastra(login);
            }

            return false;
        }

        public UsuarioLogin Retorna(UsuarioLogin login)
        {
            if (IsValido(login))
            {
                return _repositorio.Retorna(login);
            }

            return default(UsuarioLogin);
        }

        public UsuarioLogin RetornaLogin(string login)
        {
            return _repositorio.RetornaLogin(login);
        }

        private bool LoginExistePara(string nomeUsuario)
        {
            return _repositorio.LoginExistePara(nomeUsuario);
        }

        private bool IsValido(UsuarioLogin login)
        {
            var validacao = new ValidaUsuarioLogin(_globalizacao);
            return validacao.Validate(login).IsValid;
        }

    }
}
