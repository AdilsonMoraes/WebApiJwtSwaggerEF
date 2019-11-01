using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Enums.TokenAuthCliente.v1
{
    public class TokenAutorizacaoPorClienteEnum : BaseEnum<TokenAutorizacaoPorClienteEnum, string>
    {
        public static TokenAutorizacaoPorClienteEnum TOKEN_ADM =
            new TokenAutorizacaoPorClienteEnum(1, "8DBB1FE7268AF062C8355080AF9EBB362C24BE6C68B78290CB04FBA6DEF7E0A4");

        public static TokenAutorizacaoPorClienteEnum TOKEN_DEFAULT =
            new TokenAutorizacaoPorClienteEnum(2, "EA996B411B57201D59843457807F701BF4CEBAA6A11C374C05DBB89B8BD2A7E1");

        protected TokenAutorizacaoPorClienteEnum(int codigo, string valor) : base(codigo, valor)
        {
        }
    }
}
