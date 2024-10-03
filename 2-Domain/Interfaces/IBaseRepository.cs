using RendaFixa.Domain.Entities;

namespace RendaFixa.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task InsertAsync(TEntity obj, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity obj, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
    Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken);
}
