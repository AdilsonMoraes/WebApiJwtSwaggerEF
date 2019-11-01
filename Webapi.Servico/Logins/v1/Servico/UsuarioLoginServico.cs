using Microsoft.Extensions.Localization;
using WebApi.Dominio.Globalizacao.v1;
using WebApi.Dominio.Login.v1;
using WebApi.Dominio.Mensagens.v1;
using WebApi.DTO.Login.v1;
using WebApi.Enums.Exceptions.Login.v1;
using WebApi.Interface.Infraestrutura.Login.v1;
using WebApi.Interface.Servico.Login.v1;

namespace Webapi.Servico.Logins.v1.Servico
{
    public class UsuarioLoginServico : IUsuarioLoginServico
    {

        private readonly IUsuarioLoginRepositorio _usuarioRepositorio;
        private readonly IStringLocalizer<Textos> _globalizacao;

        public UsuarioLoginServico(IUsuarioLoginRepositorio usuarioRepositorio,
                                    IStringLocalizer<Textos> globalizacao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _globalizacao = globalizacao;
        }

        public void AlteraSenhaDo(string login, string senha)
        {
            var usuarioCadastrado = _usuarioRepositorio.RetornaLogin(login);
            if (usuarioCadastrado != null)
            {
                usuarioCadastrado.Senha = senha;
                var ret = _usuarioRepositorio.AlteraSenhaDo(usuarioCadastrado);

                if (!ret)
                {
                    throw new ErroException(LoginEnumException.ERRO_ALTERACAO_LOGIN.Codigo.ToString(),
                        LoginEnumException.ERRO_ALTERACAO_LOGIN.Valor);
                }
            }
            else
            {
                throw new ErroException(LoginEnumException.USUARIO_INVALIDO.Codigo.ToString(),
                    LoginEnumException.USUARIO_INVALIDO.Valor);
            }

        }

        public void Cadastra(UsuarioLogin login)
        {
            LoginExistePara(login.Usuario);
            _usuarioRepositorio.Cadastra(login);
        }

        public UsuarioLogin Retorna(UsuarioLogin user)
        {
            var ret = default(UsuarioLogin);

            if (!string.IsNullOrWhiteSpace(user.Usuario) && !string.IsNullOrWhiteSpace(user.Senha))
            {
                ret = _usuarioRepositorio.Retorna(user.Usuario, user.Senha);
            }

            return ret;
        }

        public UsuarioLogin RetornaLogin(string login)
        {
            return _usuarioRepositorio.RetornaLogin(login);
        }

        private void LoginExistePara(string nomeUsuario)
        {
            var ExisteLogin = _usuarioRepositorio.LoginExistePara(nomeUsuario);

            if (ExisteLogin)
            {
                throw new ErroException(LoginEnumException.LOGIN_JA_CADASTRADO.Codigo.ToString(),
                    LoginEnumException.LOGIN_JA_CADASTRADO.Valor);
            }
        }
    }
}
