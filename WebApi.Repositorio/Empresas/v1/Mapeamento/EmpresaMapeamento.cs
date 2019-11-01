using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Dominio.Empresas.v1;

namespace WebApi.infraestrutura.Empresas.v1.Mapeamento
{
    public class EmpresaMapeamento : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {

            builder.ToTable("empresa");

            builder.HasKey(p => p.Id);

            builder.Property(h => h.NomeFantasia)
                .HasColumnName("nome_fantasia")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(h => h.Uf)
                .HasColumnName("uf")
                .HasMaxLength(2)
                .IsRequired();

            builder.Property(h => h.Cnpj)
                .HasColumnName("cnpj")
                .HasMaxLength(14)
                .IsRequired();

    }
    }
}
