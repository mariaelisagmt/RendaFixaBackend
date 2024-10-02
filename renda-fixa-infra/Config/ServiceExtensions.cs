using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RendaFixa.Domain.Interfaces;
using RendaFixa.Infrastruct.Context;
using RendaFixa.Infrastruct.Repositories;

namespace RendaFixa.Infrastruct.Config;

public static class ServiceExtensions
{
    public static void ConfigureInfrastructApp(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("SqlServer");
        services.AddDbContext<AppDbContext>(op => op.UseSqlServer(connectionString));

        services.AddScoped<IAporteRepository, AporteRepository>();
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<IContaRepository, ContaRepository>();
        services.AddScoped<IProdutoRendaFixaRepository, ProdutoRendaFixaRepository>();
    }
}