using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Fornecedores.v1;

namespace WebApi.Dominio.Empresas.v1
{
    public class Empresa
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("nome_fantasia")]
        public string NomeFantasia { get; set; }
        [JsonProperty("uf")]
        public string Uf { get; set; }
        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        public ICollection<Fornecedor> Fornecedores { get; set; }
    }
}
