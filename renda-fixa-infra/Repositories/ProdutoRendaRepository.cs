using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;
using RendaFixa.Infrastruct.Context;

namespace RendaFixa.Infrastruct.Repository;

public class ProdutoRendaFixaRepository : BaseRepository<ProdutoRendaFixa>, IProdutoRendaFixaRepository
{
    public ProdutoRendaFixaRepository(AppDbContext contexto) : base(contexto)
    {}

}