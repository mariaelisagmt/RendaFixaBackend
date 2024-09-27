using Microsoft.Extensions.Logging;
using renda_fixa_infra.Repository;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.Service.Services;
public class ProdutoRendaFixaService : IProdutoRendaFixaService
{
    private readonly ILogger<ProdutoRendaFixaService> log;
    private readonly BaseRepository<ProdutoRendaFixa> repositorio;
    public ProdutoRendaFixaService(
        ILogger<ProdutoRendaFixaService> log,
        BaseRepository<ProdutoRendaFixa> repositorio)
    {
        this.log = log;
        this.repositorio = repositorio;
    }

    public async Task<IList<ProdutoRendaFixa>> GetAllAsync()
    {
        var resultado = await repositorio.GetAllAsync();
        return resultado;
    }

    public async Task ComprarAsync() { }
    public async Task<ProdutoRendaFixa> GetByIdAsync(Guid id) 
    {
        var resultado = await repositorio.GetByIdAsync(id);
        return resultado;
    }
}
