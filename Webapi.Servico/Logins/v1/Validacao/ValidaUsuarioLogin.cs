using FluentValidation;
using WebApi.Dominio.Globalizacao.v1;
using WebApi.Dominio.Login.v1;
using Microsoft.Extensions.Localization;

namespace Webapi.Servico.Logins.v1.Validacao
{
    public class ValidaUsuarioLogin : AbstractValidator<UsuarioLogin>
    {
        public ValidaUsuarioLogin(IStringLocalizer<Textos> localizer)
        {
            RuleFor(x => x.Usuario)
                .NotEmpty()
                .WithErrorCode("1")
                .WithMessage(localizer["O usuário é obrigatório"]);

            RuleFor(x => x.Senha)
                .NotEmpty()
                .WithErrorCode("1")
                .WithMessage(localizer["A senha é obrigatória"]);
        }


    }
}
