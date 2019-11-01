using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using WebApi.Dominio.Mensagens.v1.Enum;

namespace WebApi.Dominio.Mensagens.v1
{
    public class MensagemResposta
    {
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MensagemRespostaStatus? Status { get; set; }

        [JsonProperty("dados")]
        public string Dados { get; set; }

        [JsonProperty("erros")]
        public IEnumerable<Erro.v1.Erro> Erros { get; set; }
    }
}
