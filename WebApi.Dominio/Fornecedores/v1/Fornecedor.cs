using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Empresas.v1;

namespace WebApi.Dominio.Fornecedores.v1
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string CpfCnpjFornecedor { get; set; }
        public string CpfCnpjEmpresa { get; set; }
        public DateTime DtCadastro { get; set; } 
        public string Telefone { get; set; }
        public DateTime DtNascimento { get; set; }
        public string TpCadastro { get; set; }
        public string Rg { get; set; }

        public virtual Empresa Empresas { get; set; }
    }
}
