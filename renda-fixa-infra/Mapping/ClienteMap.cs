using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RendaFixa.Domain.Entities;

namespace renda_fixa_infra.Mapping;

public class ClienteMap : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nome)
            .HasConversion(p => p.ToString(), p => p)
            .HasColumnName("nome")
            .HasColumnType("varchar(100)");

        builder.Property(p => p.DataNascimento)
            .HasColumnName("data_nascimento")
            .HasColumnType("datetime");

        builder.Property(p => p.CPF)
            .HasColumnName("cpf")
            .HasColumnType("varchar(20)");
    }
}
