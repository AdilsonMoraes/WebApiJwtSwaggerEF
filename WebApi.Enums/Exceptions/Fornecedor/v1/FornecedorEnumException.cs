using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Enums.Exceptions.Fornecedor.v1
{
    public class FornecedorEnumException : BaseEnum<FornecedorEnumException, string>
    {
        //public static FornecedorEnumException FORNECEDOR_INVALIDO = new FornecedorEnumException(6, "");
        //public static FornecedorEnumException FORNECEDOR_NAO_INFORMADO = new FornecedorEnumException(7, "");

        protected FornecedorEnumException(int codigo, string valor) : base(codigo, valor)
        {
        }
    }
}
