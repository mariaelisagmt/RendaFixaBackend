using RendaFixa.Domain.Entities;

namespace RendaFixa.Domain.Interfaces;

public interface IProdutoRendaFixaService
{
    Task ComprarAsync(int produtoId, int contaId, int quantidade);
    Task<Conta> GetContaAsync(int contaId);
    Task<IList<ProdutoRendaFixa>> GetAllAsync();
    Task<ProdutoRendaFixa> GetByIdAsync(int id);
}
