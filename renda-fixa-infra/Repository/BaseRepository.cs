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
    public async Task InsertAsync(TEntity objeto)
    {
        await Contexto.Set<TEntity>().AddAsync(objeto);
        await Contexto.SaveChangesAsync();
    }
    public async Task UpdateAsync(TEntity objeto)
    {
        Contexto.Entry(objeto).State = EntityState.Modified;
        await Contexto.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            Contexto.Set<TEntity>().Remove(entity);
            await Contexto.SaveChangesAsync();
        }
    }
    public async Task<IList<TEntity>> GetAllAsync() => await Contexto.Set<TEntity>().ToListAsync();
    public async Task<TEntity> GetByIdAsync(int id) => await Contexto.Set<TEntity>().FindAsync(id);
}