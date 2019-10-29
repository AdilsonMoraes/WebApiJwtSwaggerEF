using Microsoft.Extensions.DependencyInjection;
using Webapi.Servico.JwtAutenticacao.v1;
using Webapi.Servico.Logins.v1.Servico;
using WebApi.Dominio.Jwt.v1;
using WebApi.infraestrutura.InterfaceGenerica.v1.Repositorio;
using WebApi.infraestrutura.Login.v1.Repositorio;
using WebApi.Interface.Infraestrutura.InterfaceGenerica.v1;
using WebApi.Interface.Infraestrutura.Login.v1;
using WebApi.Interface.Servico.Jwt;
using WebApi.Interface.Servico.Login.v1;

namespace WebApiIoC
{
    public static class BootStrap
    {
        public static void RegistrarServico(IServiceCollection services)
        {
            Login(services);
            UnitOfWork(services);
            Autenticacao(services);            
        }

        private static void Login(IServiceCollection services)
        {
            services.AddTransient<IUsuarioLoginRepositorio, UsuarioLoginRepositorio>();
            services.AddTransient<IUsuarioLoginServico, UsuarioLoginServico>();
        }

        private static void UnitOfWork(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }


        private static void Autenticacao(IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddSingleton<JwtTokenSettings>();
        }

    }
}
