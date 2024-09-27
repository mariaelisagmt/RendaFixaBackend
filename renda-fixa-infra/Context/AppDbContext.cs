using Microsoft.EntityFrameworkCore;
using renda_fixa_infra.Mapping;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Infrastruct.Context;

public class AppDbContext : DbContext
{
    public AppDbContext() { }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Cliente { get; set; }
    public DbSet<ContaMap> Conta { get; set; }
    public DbSet<Aporte> Aporte { get; set; }
    public DbSet<ProdutoRendaFixa> ProdutoRendaFixa { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
        modelBuilder.Entity<Conta>(new ContaMap().Configure);
        modelBuilder.Entity<Aporte>(new AporteMap().Configure);
        modelBuilder.Entity<ProdutoRendaFixa>(new ProdutoRendaFixaMap().Configure);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=monorail.proxy.rlwy.net;Port=19735;Database=Toro;User=root;Password=hfTOivBbiGUJueruCKMQdhZhwlwJCriH");
    }
}