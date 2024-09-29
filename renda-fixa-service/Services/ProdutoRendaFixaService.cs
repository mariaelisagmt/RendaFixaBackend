using Microsoft.Extensions.Logging;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.Service.Services;
public class ProdutoRendaFixaService : IProdutoRendaFixaService
{
    private readonly ILogger<ProdutoRendaFixaService> log;
    private readonly IBaseRepository<ProdutoRendaFixa> repositorio;
    public ProdutoRendaFixaService(
        ILogger<ProdutoRendaFixaService> log,
        IBaseRepository<ProdutoRendaFixa> repositorio)
    {
        this.log = log;
        this.repositorio = repositorio;
    }

    public async Task<IList<ProdutoRendaFixa>> GetAllAsync()
    {
        log.LogInformation("Obtendo todos os produtos de renda fixa.");
        var resultado = await repositorio.GetAllAsync();
        return resultado;
    }

    public async Task<ProdutoRendaFixa> GetByIdAsync(Guid id) 
    {
        log.LogInformation($"Obtendo o produto de renda fixa com id {id}");
        var resultado = await repositorio.GetByIdAsync(id);
        return resultado;
    }
}