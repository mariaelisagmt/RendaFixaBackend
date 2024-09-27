using RendaFixa.Domain.Entities;

namespace RendaFixa.Domain.Interfaces;

public interface IProdutoRendaFixaService
{
    Task ComprarAsync();
    Task<IList<ProdutoRendaFixa>> GetAllAsync();
    Task<ProdutoRendaFixa> GetByIdAsync(Guid id);
}
