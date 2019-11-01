using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WebApi.Dominio.Fornecedores.v1;

namespace WebApi.infraestrutura.Fornecedores.v1.Mapeamento
{
    public class FornecedorMapeamento : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("fornecedor");

            builder.HasKey(p => p.Id);

            builder.Property(h => h.Nome)
                .HasColumnName("nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(h => h.CpfCnpjFornecedor)
                .HasColumnName("cpf_cnpj")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(h => h.DtCadastro)
                .HasColumnName("dt_cadastro")
                .HasMaxLength(14)
                .HasDefaultValue(DateTime.Now);

            builder.Property(h => h.Telefone)
                .HasColumnName("telefone")
                .HasMaxLength(12);

            builder.Property(h => h.DtNascimento)
                .HasColumnName("dt_nascimento");

            builder.Property(h => h.TpCadastro)
                .HasColumnName("tp_cadasdro")
                .HasMaxLength(14);

            builder.Property(h => h.Rg)
                .HasColumnName("rg")
                .HasMaxLength(9);

            builder.HasOne(h => h.Empresas)
            .WithMany(f => f.Fornecedores)
            .HasForeignKey(e => e.IdEmpresa);
        }
    }
}
