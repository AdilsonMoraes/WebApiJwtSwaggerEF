using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Empresas.v1;

namespace WebApi.Dominio.Fornecedores.v1
{
    public class Fornecedor
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("id_empresa")]
        public int IdEmpresa { get; set; }
        [JsonProperty("nome_empresa")]
        public string Nome { get; set; }
        [JsonProperty("cpf_cnpj")]
        public string CpfCnpj { get; set; }
        [JsonProperty("data_cadastro")]
        public DateTime DtCadastro { get; set; }
        [JsonProperty("telefone")]
        public string Telefone { get; set; }
        [JsonProperty("data_nascimento")]
        public DateTime DtNascimento { get; set; }
        [JsonProperty("tipo_cadastro")]
        public string TpCadastro { get; set; }
        [JsonProperty("rg")]
        public string Rg { get; set; }

        public virtual Empresa Empresas { get; set; }
    }
}
