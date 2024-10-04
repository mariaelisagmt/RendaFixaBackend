using Microsoft.EntityFrameworkCore;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;
using RendaFixa.Infrastruct.Context;

namespace RendaFixa.Infrastruct.Repositories;

public class ProdutoRendaFixaRepository : BaseRepository<ProdutoRendaFixa>, IProdutoRendaFixaRepository
{
    public ProdutoRendaFixaRepository(AppDbContext contexto) : base(contexto)
    { }
    public async Task<IList<ProdutoRendaFixa>> GetProdutosAsync(CancellationToken cancellationToken)
    {
        var produtos = await contexto.ProdutoRendaFixa
            .OrderByDescending(x => x.Taxa)
            .ToListAsync(cancellationToken);

        if (produtos == null)
        {
            return [];
        }

        return produtos;
    }
}