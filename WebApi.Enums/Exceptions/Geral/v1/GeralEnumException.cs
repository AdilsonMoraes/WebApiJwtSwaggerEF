using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Enums.Exceptions.Geral.v1
{
    public class GeralEnumException : BaseEnum<GeralEnumException, string>
    {
        public static GeralEnumException TOKEN_NAO_INFORMADO = new GeralEnumException(6, "Token em branco e/ou não informado.");
        public static GeralEnumException TOKEN_INVALIDO = new GeralEnumException(7, "Token inválido.");

        protected GeralEnumException(int codigo, string valor) : base(codigo, valor)
        {
        }


    }
}
