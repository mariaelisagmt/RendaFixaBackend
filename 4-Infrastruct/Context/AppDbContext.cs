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
    }
}