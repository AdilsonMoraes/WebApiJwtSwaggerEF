using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.DTO.Fornecedor.v1
{
    public class ConsultaFornecedorDTO
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("cpf_cnpj_fornecedor")]
        public string CpfCnpjFornecedor { get; set; }
        [JsonProperty("data_cadastro")]
        public string DtCadastro { get; set; }
    }
}
