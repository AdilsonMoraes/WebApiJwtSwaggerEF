using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTO.Fornecedor.v1
{
    public class FornecedorDTO
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("cpf_cnpj_fornecedor")]
        public string CpfCnpjFornecedor { get; set; }

        [JsonProperty("cpf_cnpj_empresa")]
        public string CpfCnpjEmpresa { get; set; }

        [JsonProperty("data_cadastro")]
        public string DtCadastro { get; set; }

        [JsonProperty("telefone")]
        public string Telefone { get; set; }

        [JsonProperty("data_nascimento")]
        public string DtNascimento { get; set; }

        [JsonProperty("tipo_cadasdro")]
        public string TpCadastro { get; set; }

        [JsonProperty("rg")]
        public string Rg { get; set; }
    }
}
