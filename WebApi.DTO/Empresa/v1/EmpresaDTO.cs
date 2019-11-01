using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApi.Dominio.Autorizacoes.v1;
using WebApi.Enums.Exceptions.Empresa.v1;
using WebApi.Enums.Exceptions.Geral.v1;

namespace WebApi.DTO.Empresa.v1
{
    public class EmpresaDTO : BaseDTO, IAutorizacao, IValidatableObject
    {
        [JsonProperty("nome_fantasia")]
        public string NomeFantasia { get; set; }
        [JsonProperty("uf")]
        public string Uf { get; set; }
        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }
        [JsonProperty("token")]
        public string token_auth { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(NomeFantasia) || string.IsNullOrWhiteSpace(NomeFantasia))
            {
                yield return new ValidationResult(EmpresaEnumException.FANTASIA_NAO_INFORMADO.ToString());
            }

            if (string.IsNullOrEmpty(Uf) || string.IsNullOrWhiteSpace(Uf))
            {
                yield return new ValidationResult(EmpresaEnumException.UF_NAO_INFORMADO.ToString());
            }

            if (string.IsNullOrEmpty(Cnpj) || string.IsNullOrWhiteSpace(Cnpj))
            {
                yield return new ValidationResult(EmpresaEnumException.CNPJ_NAO_INFORMADO.ToString());
            }

            if (string.IsNullOrEmpty(token_auth) || string.IsNullOrWhiteSpace(token_auth))
            {
                yield return new ValidationResult(GeralEnumException.TOKEN_NAO_INFORMADO.ToString());
            }
        }
    }
}
