using RendaFixa.Domain.Entities;

namespace RendaFixa.Domain.Interfaces;

public interface IProdutoRendaFixaRepository : IBaseRepository<ProdutoRendaFixa>
{
    Task<IList<ProdutoRendaFixa>> GetProdutosAsync(CancellationToken cancellationToken);
}
