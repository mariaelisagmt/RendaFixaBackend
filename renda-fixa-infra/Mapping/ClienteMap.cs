using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Infrastruct.Mapping;

public class ClienteMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .HasColumnName("nome")
            .HasColumnType("varchar(255)")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.DataNascimento)
            .HasColumnName("data_nascimento")
            .HasColumnType("datetime")
            .IsRequired();

        builder.Property(p => p.CPF)
            .HasConversion(prop => prop.ToString(), prop => prop)
            .HasColumnName("cpf")
            .HasColumnType("varchar(11)")
            .IsRequired();
    }
}
