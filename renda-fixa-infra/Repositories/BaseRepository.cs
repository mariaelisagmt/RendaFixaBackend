using Microsoft.EntityFrameworkCore;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;
using RendaFixa.Infrastruct.Context;

namespace RendaFixa.Infrastruct.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext contexto;
    public BaseRepository(AppDbContext contexto)
    {
        this.contexto = contexto;
    }
    public async Task InsertAsync(TEntity objeto, CancellationToken cancellationToken)
    {
        await contexto.Set<TEntity>().AddAsync(objeto);
        await contexto.SaveChangesAsync(cancellationToken);
    }
    public async Task UpdateAsync(TEntity objeto, CancellationToken cancellationToken)
    {
        contexto.Entry(objeto).State = EntityState.Modified;
        await contexto.SaveChangesAsync(cancellationToken);
    }
    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity != null)
        {
            contexto.Set<TEntity>().Remove(entity);
            await contexto.SaveChangesAsync(cancellationToken);
        }
    }
    public async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken) => await contexto.Set<TEntity>().ToListAsync(cancellationToken);
    public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken) => await contexto.Set<TEntity>().FindAsync(id, cancellationToken);
}