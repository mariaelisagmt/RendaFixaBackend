using RendaFixa.Domain.Entities;

namespace RendaFixa.Domain.Interfaces;

public interface IAporteRepository : IBaseRepository<Aporte>
{
    Task<Aporte> CreateAsync(int contaId, int produtoId, int quantidade, CancellationToken cancellationToken);
    Task<IList<Aporte>> GetAllByContaAsync(int contaId, CancellationToken cancellationToken);
}
