using Microsoft.EntityFrameworkCore;
using RendaFixa.Domain.Entities;
using RendaFixa.Infrastruct.Mapping;

namespace RendaFixa.Infrastruct.Context;

public class AppDbContext : DbContext
{
    public AppDbContext() { }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Cliente { get; set; }
    public virtual DbSet<Conta> Conta { get; set; }
    public DbSet<Aporte> Aporte { get; set; }
    public DbSet<ProdutoRendaFixa> ProdutoRendaFixa { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
        modelBuilder.Entity<Conta>(new ContaMap().Configure);
        modelBuilder.Entity<Aporte>(new AporteMap().Configure);
        modelBuilder.Entity<ProdutoRendaFixa>(new ProdutoRendaFixaMap().Configure);
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>().HasData(
            new Cliente(id: 1, nome: "João Silva", cPF: "12345678901", dataNascimento: new DateTime(1995, 5, 15))
        );

        modelBuilder.Entity<Conta>().HasData(
            new Conta(id: 1, clienteId: 1, codigo: 1001, saldo: 5000.00m)
        );

        modelBuilder.Entity<ProdutoRendaFixa>().HasData(
            new ProdutoRendaFixa(id: 1, nome: "Tesouro Direto", indexador: "Selic", precoUnitario: 100.0000m, taxa: 5.0000m, estoque: 100),
            new ProdutoRendaFixa(id: 2, nome: "CDBs", indexador: "CDI", precoUnitario: 55.0000m, taxa: 3.0000m, estoque: 50),
            new ProdutoRendaFixa(id: 3, nome: "Debêntures", indexador: "IPCA", precoUnitario: 25.0000m, taxa: 4.0000m, estoque: 200),
            new ProdutoRendaFixa(id: 4, nome: "Fundos de Renda Fixa", indexador: "IGPM", precoUnitario: 30.0000m, taxa: 6.0000m, estoque: 150),
            new ProdutoRendaFixa(id: 5, nome: "LCIs", indexador: "IPCA", precoUnitario: 70.0000m, taxa: 5.0000m, estoque: 75),
            new ProdutoRendaFixa(id: 6, nome: "LCAs", indexador: "CDI", precoUnitario: 45.0000m, taxa: 3.0000m, estoque: 60),
            new ProdutoRendaFixa(id: 7, nome: "CRIs", indexador: "IGPM", precoUnitario: 60.0000m, taxa: 4.0000m, estoque: 30),
            new ProdutoRendaFixa(id: 8, nome: "CRAs", indexador: "Selic", precoUnitario: 80.0000m, taxa: 6.0000m, estoque: 40),
            new ProdutoRendaFixa(id: 9, nome: "Carteiras digitais remuneradas", indexador: "CDI", precoUnitario: 50.0000m, taxa: 3.0000m, estoque: 20),
            new ProdutoRendaFixa(id: 10, nome: "Letra de Câmbio (LC)", indexador: "IPCA", precoUnitario: 90.0000m, taxa: 5.0000m, estoque: 10)
        );
    }
}