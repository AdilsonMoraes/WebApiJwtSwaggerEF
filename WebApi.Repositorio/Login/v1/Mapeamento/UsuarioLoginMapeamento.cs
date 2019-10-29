using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Dominio.Login.v1;

namespace WebApi.infraestrutura.Login.v1.Mapeamento
{
    public class UsuarioLoginMapeamento : IEntityTypeConfiguration<UsuarioLogin>
    {
        public void Configure(EntityTypeBuilder<UsuarioLogin> builder)
        {
            builder.ToTable("usuario_login");

            builder.HasKey(p => p.Usuario);

            builder.Property(h => h.Usuario)
                .HasColumnName("Usuario")
                .IsUnicode(false)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(h => h.Senha)
                .HasColumnName("Senha")
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
