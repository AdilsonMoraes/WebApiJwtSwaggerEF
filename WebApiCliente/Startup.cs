using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System.Globalization;
using WebApi.Dominio.Jwt.v1;
using WebApi.infraestrutura.Contextos.v1;
using WebApiIoC;
using static System.Text.Encoding;

namespace WebApiCliente
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            Globalization(services);

            services
                .AddMvcCore()
                .AddVersionedApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            services.AddMvc()
                .AddDataAnnotationsLocalization()
                .AddJsonOptions(options => {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            services.AddApiVersioning();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(
                options =>
                {
                    var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
                    }
                });


            var jwtConfiguration = Configuration
                .GetSection(nameof(JwtTokenSettings));
            services.Configure<JwtTokenSettings>(jwtConfiguration);
            var jwtTokenSettings = jwtConfiguration
                .Get<JwtTokenSettings>();

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(UTF8
                        .GetBytes(jwtTokenSettings.IssuerSigningKey))
                };
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ElevatedRights", policy => policy.RequireClaim("a"));
            });

            services.AddCors(o =>
            {
                o.AddPolicy("default", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });


            BootStrap.RegistrarServico(services);

            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });
            
            services.AddDbContext<ContextoSql>(options => options.UseSqlServer(Configuration.GetConnectionString("ConexaoSql")));

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IApiVersionDescriptionProvider provider,
            ILoggerFactory loggerFactory)
        {

            loggerFactory
                .AddConsole()
                .AddDebug();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);



            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
#if DEBUG
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
#else
                        options.SwaggerEndpoint($"/Api.Cliente/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
#endif



                    }
                });


        }

        static Info CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new Info()
            {
                Title = $"WebApi Cliente {description.ApiVersion}",
                Version = description.ApiVersion.ToString(),
                Description = "API Cliente."
            };

            if (description.IsDeprecated)
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }

        public void Globalization(IServiceCollection services)
        {
            services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                                    {
                              new CultureInfo("pt-BR"),
                              new CultureInfo("en-US")
                          };
                options.DefaultRequestCulture = new RequestCulture("en-US", "en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }
    }
}
