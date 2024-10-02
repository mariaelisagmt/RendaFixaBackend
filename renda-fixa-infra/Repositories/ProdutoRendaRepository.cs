using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;
using RendaFixa.Infrastruct.Context;

namespace RendaFixa.Infrastruct.Repository;

public class ProdutoRendaFixaRepository : BaseRepository<ProdutoRendaFixa>, IProdutoRendaFixaRepository
{
    private readonly ILogger<AporteRepository> logger;
    public ProdutoRendaFixaRepository(AppDbContext contexto, ILogger<AporteRepository> logger) : base(contexto)
    { }
    public async Task<IList<ProdutoRendaFixa>> GetProdutosAsync(CancellationToken cancellationToken)
    {
        try
        {
            var aportes = await contexto.ProdutoRendaFixa
                .OrderByDescending(x => x.Taxa)
                .ToListAsync(cancellationToken);

            if (aportes == null)
            {
                logger.LogError($"Erro ao buscar lista de produtos de renda fixa.");
                return new List<ProdutoRendaFixa>();
            }

            return aportes;

        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao buscar listas de produtos de renda fixa");
            return new List<ProdutoRendaFixa>();
        }
    }

}