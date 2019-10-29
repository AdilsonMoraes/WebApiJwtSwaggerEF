using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Dominio.Mensagens.v1
{
    public class ErroException : Exception
    {
        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        public ErroException(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }
    }
}
