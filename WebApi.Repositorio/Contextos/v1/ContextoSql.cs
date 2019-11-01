using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Dominio.Empresas.v1;
using WebApi.Dominio.Fornecedores.v1;
using WebApi.Dominio.Login.v1;
using WebApi.infraestrutura.Empresas.v1.Mapeamento;
using WebApi.infraestrutura.Fornecedores.v1.Mapeamento;
using WebApi.infraestrutura.Login.v1.Mapeamento;

namespace WebApi.infraestrutura.Contextos.v1
{
    public class ContextoSql : DbContext
    {
        public virtual DbSet<UsuarioLogin> Logins { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Fornecedor> Fornecedores { get; set; }

        public ContextoSql(DbContextOptions<ContextoSql> options) : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioLoginMapeamento());
            modelBuilder.ApplyConfiguration(new EmpresaMapeamento());
            modelBuilder.ApplyConfiguration(new FornecedorMapeamento());

        }

    }
}
