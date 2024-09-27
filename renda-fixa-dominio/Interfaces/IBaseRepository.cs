using RendaFixa.Domain.Entities;

namespace RendaFixa.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task InsertAsync(TEntity obj);
    Task UpdateAsync(TEntity obj);
    Task DeleteAsync(Guid id);
    Task<IList<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(Guid id);
}
