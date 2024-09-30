using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Infrastruct.Mapping;

public class ContaMap : IEntityTypeConfiguration<Conta>
{
    public void Configure(EntityTypeBuilder<Conta> builder)
    {
        builder.ToTable("conta");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.ClienteId)
            .HasColumnName("cliente_fk")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Codigo)
            .HasColumnName("codigo")
            .HasColumnType("int")
            .IsRequired();
        
        builder.Property(p => p.Saldo)
            .HasColumnName("saldo")
            .HasColumnType("decimal")
            .IsRequired();

        builder.HasOne(x => x.Cliente)
            .WithMany(y => y.Contas)
            .HasForeignKey(x => x.ClienteId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Aportes)
            .WithOne(y => y.Conta)
            .HasForeignKey(y => y.ContaId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}