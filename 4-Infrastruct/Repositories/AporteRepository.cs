using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;
using RendaFixa.Infrastruct.Context;

namespace RendaFixa.Infrastruct.Repositories;

public class AporteRepository : BaseRepository<Aporte>, IAporteRepository
{
    private readonly ILogger<AporteRepository> logger;
    public AporteRepository(
         AppDbContext contexto,
         ILogger<AporteRepository> logger) : base(contexto)
    {
        this.logger = logger;
    }

    public async Task<IList<Aporte>> GetAllByContaAsync(int contaId, CancellationToken cancellationToken)
    {
        try
        {
            var conta = await contexto.Conta.FirstOrDefaultAsync(x => x.Id == contaId, cancellationToken);

            if (conta == null)
            {
                logger.LogError($"Erro ao encontrar a conta com id {contaId}");
                return new List<Aporte>();
            }

            var aportes = await contexto.Aporte
                .Where(x => x.ContaId == conta.Id)
                .OrderBy(x => x.DataOperacao)
                .ToListAsync(cancellationToken);

            if (aportes == null)
            {
                logger.LogError($"Erro ao encontrar aportes para a conta id {contaId}");
                return new List<Aporte>();
            }

            return aportes;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"Erro ao encontrar aportes para a conta id {contaId}");
            return new List<Aporte>();
        }
    }

    public async Task CreateAsync(int contaId, int produtoId, int quantidade, CancellationToken cancellationToken)
    {
        using var transaction = await contexto.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var conta = await contexto.Conta.FirstOrDefaultAsync(x => x.Id == contaId, cancellationToken);

            if (conta == null)
            {
                logger.LogError($"Erro ao encontrar a conta com id {contaId}");
                return;
            }

            var produto = await contexto.ProdutoRendaFixa.FirstOrDefaultAsync(x => x.Id == produtoId, cancellationToken);

            if (produto == null)
            {
                logger.LogError($"Erro ao encontrar um produto de renda fixa com id {produtoId}");
                return;
            }

            if (quantidade <= produto.Estoque)
            {
                var calculo = produto.PrecoUnitario * quantidade;

                if (calculo <= conta.Saldo)
                {
                    conta.Debitar(calculo);
                    contexto.Conta.Update(conta);

                    var entidade = new Aporte(produtoId, contaId, DateTime.Now, quantidade);
                    await contexto.Aporte.AddAsync(entidade, cancellationToken);

                    produto.BaixarEstoque(quantidade);
                    contexto.ProdutoRendaFixa.Update(produto);

                    await contexto.SaveChangesAsync(cancellationToken);

                    await transaction.CommitAsync(cancellationToken);
                }
                else
                {
                    logger.LogError($"Saldo insuficiente na conta {contaId} para realizar o aporte.");
                }
            }
            else
            {
                logger.LogError($"Estoque insuficiente para o produto {produtoId}.");
            }

        }
        catch (Exception ex)
        {
            logger.LogError($"Erro ao realizar a operação de aporte: {ex.Message}");
            await transaction.RollbackAsync(cancellationToken);
        }
    }
}