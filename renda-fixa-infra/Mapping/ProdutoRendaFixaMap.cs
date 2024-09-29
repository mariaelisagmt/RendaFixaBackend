using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Infrastruct.Mapping;

public class ProdutoRendaFixaMap : IEntityTypeConfiguration<ProdutoRendaFixa>
{
    public void Configure(EntityTypeBuilder<ProdutoRendaFixa> builder)
    {
        builder.ToTable("produto_renda_fixa");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .HasColumnName("nome")
            .HasColumnType("varchar(200)");

        builder.Property(p => p.Indexador)
            .HasColumnName("indexador")
            .HasColumnType("varchar(100)");

        builder.Property(p => p.PrecoUnitario)
            .HasColumnName("preco_unitario")
            .HasColumnType("decimal");

        builder.Property(p => p.Taxa)
            .HasColumnName("taxa")
            .HasColumnType("decimal");

        builder.Property(p => p.Estoque)
            .HasColumnName("estoque")
            .HasColumnType("int");

        builder.HasMany(x => x.Aportes)
            .WithOne(y => y.RendaFixa)
            .HasForeignKey(y => y.RendaFixaId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
