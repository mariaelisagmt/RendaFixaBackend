using Microsoft.EntityFrameworkCore;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;
using RendaFixa.Infrastruct.Context;

namespace RendaFixa.Infrastruct.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext Contexto;
    public BaseRepository(AppDbContext contexto)
    {
        Contexto = contexto;
    }
    public async Task InsertAsync(TEntity objeto, CancellationToken cancellationToken)
    {
        await Contexto.Set<TEntity>().AddAsync(objeto);
        await Contexto.SaveChangesAsync(cancellationToken);
    }
    public async Task UpdateAsync(TEntity objeto, CancellationToken cancellationToken)
    {
        Contexto.Entry(objeto).State = EntityState.Modified;
        await Contexto.SaveChangesAsync(cancellationToken);
    }
    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id, cancellationToken);
        if (entity != null)
        {
            Contexto.Set<TEntity>().Remove(entity);
            await Contexto.SaveChangesAsync(cancellationToken);
        }
    }
    public async Task<IList<TEntity>> GetAllAsync(CancellationToken cancellationToken) => await Contexto.Set<TEntity>().ToListAsync(cancellationToken);
    public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken) => await Contexto.Set<TEntity>().FindAsync(id, cancellationToken);
}