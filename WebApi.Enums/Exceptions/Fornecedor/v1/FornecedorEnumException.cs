using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Enums.Exceptions.Fornecedor.v1
{
    public class FornecedorEnumException : BaseEnum<FornecedorEnumException, string>
    {
        public static FornecedorEnumException DADOS_NAO_INFORMADO = new FornecedorEnumException(15, "Não foraminformados dados para consulta.");

        protected FornecedorEnumException(int codigo, string valor) : base(codigo, valor)
        {
        }
    }
}
