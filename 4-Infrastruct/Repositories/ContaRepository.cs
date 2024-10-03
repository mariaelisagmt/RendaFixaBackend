using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;
using RendaFixa.Infrastruct.Context;

namespace RendaFixa.Infrastruct.Repositories;

public class ContaRepository : BaseRepository<Conta>, IContaRepository
{
    public ContaRepository(AppDbContext contexto) : base(contexto)
    { }

}