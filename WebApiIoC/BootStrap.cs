using Microsoft.Extensions.DependencyInjection;
using Webapi.Servico.Empresas.v1.Servico;
using Webapi.Servico.ErroMappers.v1;
using Webapi.Servico.Fornecedores.v1.Servico;
using Webapi.Servico.JwtAutenticacao.v1;
using Webapi.Servico.Logins.v1.Servico;
using WebApi.Dominio.Jwt.v1;
using WebApi.infraestrutura.Empresas.v1.Repositorio;
using WebApi.infraestrutura.Fornecedores.v1.Repositorio;
using WebApi.infraestrutura.InterfaceGenerica.v1.Repositorio;
using WebApi.infraestrutura.Login.v1.Repositorio;
using WebApi.Interface.Infraestrutura.Empresas.v1;
using WebApi.Interface.Infraestrutura.Fornecedores.v1;
using WebApi.Interface.Infraestrutura.InterfaceGenerica.v1;
using WebApi.Interface.Infraestrutura.Login.v1;
using WebApi.Interface.Servico.Empresa.v1;
using WebApi.Interface.Servico.ErroMapper.v1;
using WebApi.Interface.Servico.Fornecedor.v1;
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
            Fornecedor(services);
            Empresa(services);
            Erro(services);
        }

        private static void Erro(IServiceCollection services)
        {
            services.AddTransient<IErrosMapperServico, ErrosMapperServico>();
        }

        private static void Login(IServiceCollection services)
        {
            services.AddTransient<IUsuarioLoginRepositorio, UsuarioLoginRepositorio>();
            services.AddTransient<IUsuarioLoginServico, UsuarioLoginServico>();
        }

        private static void UnitOfWork(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, FonecedorRepositorio>();
        }

        private static void Fornecedor(IServiceCollection services)
        {
            services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();
            services.AddScoped<IFornecedorServico, FornecedorServico>();
        }

        private static void Empresa(IServiceCollection services)
        {
            services.AddScoped<IEmpresaRepositorio, EmpresaRepositorio>();
            services.AddScoped<IEmpresaServico, EmpresaServico>();
        }

        private static void Autenticacao(IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddSingleton<JwtTokenSettings>();
        }

    }
}
