﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;
using RendaFixa.Infrastruct.Context;

namespace RendaFixa.Infrastruct.Repository;

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

    public async Task<Aporte> RealizeAsync(int contaId, int produtoId, int quantidade, CancellationToken cancellationToken)
    {
        var conta = await contexto.Conta.FirstOrDefaultAsync(x => x.Id == contaId, cancellationToken);

        if (conta == null)
        {
            logger.LogError($"Erro ao encontrar a conta com id {contaId}");
            return null;
        }

        var produto = await contexto.ProdutoRendaFixa.FirstOrDefaultAsync(x => x.Id == produtoId, cancellationToken);

        if (produto == null)
        {
            logger.LogError($"Erro ao encontrar um produto de renda fixa com id {produtoId}");
            return null;
        }

        if (quantidade < produto.Estoque)
        {
            var calculo = produto.PrecoUnitario * quantidade;
            if (calculo < conta.Saldo)
            {
                conta.Saldo -= calculo;
                await repositorioConta.UpdateAsync(conta);

                var entidade = new Aporte(produtoId, contaId, DateTime.Now, 1);
                await repositorioAporte.InsertAsync(entidade);

                produto.Estoque -= quantidade;
                await repositorio.UpdateAsync(produto);
            }
        }

        return aporte;
    }
}