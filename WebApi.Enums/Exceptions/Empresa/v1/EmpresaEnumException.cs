using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Enums.Exceptions.Empresa.v1
{
    public class EmpresaEnumException : BaseEnum<EmpresaEnumException, string>
    {
        public static EmpresaEnumException FANTASIA_NAO_INFORMADO = new EmpresaEnumException(8, "Fantasia não Informado.");
        public static EmpresaEnumException UF_NAO_INFORMADO = new EmpresaEnumException(9, "UF não Informado.");
        public static EmpresaEnumException CNPJ_NAO_INFORMADO = new EmpresaEnumException(10, "CNPJ não Informado.");
        public static EmpresaEnumException EMPRESA_NAO_ENCONTRADA = new EmpresaEnumException(12, "Empresa não encontrada no cadastro.");
        public static EmpresaEnumException EMPRESA_JA_CADASTRADA = new EmpresaEnumException(13, "Empresa já cadastrada.");
        public static EmpresaEnumException NOME_NAO_INFORMADO = new EmpresaEnumException(14, "Nome Fantasia da empresa não informado.");

        protected EmpresaEnumException(int codigo, string valor) : base(codigo, valor)
        {
        }

    }
}
