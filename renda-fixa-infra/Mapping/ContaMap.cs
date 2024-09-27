using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RendaFixa.Domain.Entities;

namespace renda_fixa_infra.Mapping;

public class ContaMap : IEntityTypeConfiguration<Conta>
{
    public void Configure(EntityTypeBuilder<Conta> builder)
    {
        builder.ToTable("conta");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.ClienteId)
            .HasColumnName("cliente_fk")
            .HasColumnType("uniquidentifier");

        builder.Property(p => p.CodigoConta)
            .HasColumnName("codigo_conta")
            .HasColumnType("int");
    }
}