using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Enums.Exceptions.Login.v1
{
    public class LoginEnumException : BaseEnum<LoginEnumException, string>
    {
        public static LoginEnumException USUARIO_INVALIDO = new LoginEnumException(3, "Usuário inválido.");
        public static LoginEnumException LOGIN_JA_CADASTRADO = new LoginEnumException(4, "Login já cadastrado.");
        public static LoginEnumException ERRO_ALTERACAO_LOGIN = new LoginEnumException(5, "Houve um problema na hora de alterar a senha.");
        public static LoginEnumException SENHA_INVALIDA = new LoginEnumException(11, "Senha inválida.");

        protected LoginEnumException(int codigo, string valor) : base(codigo, valor)
        {
        }
    }
}
