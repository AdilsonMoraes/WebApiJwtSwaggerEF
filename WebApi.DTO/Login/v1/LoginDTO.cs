using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApi.Dominio.Autorizacoes.v1;
using WebApi.Enums.Exceptions.Login.v1;

namespace WebApi.DTO.Login.v1
{
    public class LoginDTO : BaseDTO, IAutorizacao, IValidatableObject
    {
        [JsonProperty("usuario")]
        public string Usuario { get; set; }
        [JsonProperty("senha")]
        public string Senha { get; set; }
        [JsonProperty("Administrador")]
        public bool IsAdministrator { get; set; }
        [JsonProperty("token")]
        public string token_auth { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(Usuario) || string.IsNullOrWhiteSpace(Usuario))
            {
                yield return new ValidationResult(LoginEnumException.USUARIO_INVALIDO.ToString());
            }

            if (string.IsNullOrEmpty(Senha) || string.IsNullOrWhiteSpace(Senha))
            {
                yield return new ValidationResult(LoginEnumException.SENHA_INVALIDA.ToString());
            }

        }
    }
}
