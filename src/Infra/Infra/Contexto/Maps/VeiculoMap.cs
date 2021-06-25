using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infra.Contexto.Maps
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("veiculos");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Marca).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Modelo).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Quilometragem).IsRequired().HasMaxLength(100).HasColumnType("varchar(100)");
            builder.Property(x => x.Ano).IsRequired().HasMaxLength(100).HasColumnType("DATE");
        }
    }
}
