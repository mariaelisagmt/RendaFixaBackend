using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RendaFixa.Domain.Entities;

namespace renda_fixa_infra.Mapping;

public class AporteMap : IEntityTypeConfiguration<Aporte>
{
    public void Configure(EntityTypeBuilder<Aporte> builder)
    {
        builder.ToTable("aporte");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.RendaFixaId)
            .HasColumnName("renda_fixa_fk")
            .HasColumnType("uniquidentifier");

        builder.Property(p => p.ContaId)
            .HasColumnName("conta_fk")
            .HasColumnType("uniquidentifier");

        builder.Property(p => p.DataOperacao)
            .HasColumnName("data_operacao")
            .HasColumnType("datetime");

        builder.Property(p => p.Status)
            .HasColumnName("status")
            .HasColumnType("bit");
    }
}