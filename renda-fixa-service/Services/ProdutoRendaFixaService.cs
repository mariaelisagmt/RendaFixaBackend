using Microsoft.Extensions.Logging;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.Service.Services;
public class ProdutoRendaFixaService : IProdutoRendaFixaService
{
    private readonly ILogger<ProdutoRendaFixaService> log;
    private readonly IBaseRepository<ProdutoRendaFixa> repositorio;
    private readonly IBaseRepository<Aporte> repositorioAporte;
    private readonly IBaseRepository<Conta> repositorioConta;
    public ProdutoRendaFixaService(
        ILogger<ProdutoRendaFixaService> log,
        IBaseRepository<ProdutoRendaFixa> repositorio,
        IBaseRepository<Conta> repositorioConta,
        IBaseRepository<Aporte> repositorioAporte)
    {
        this.log = log;
        this.repositorio = repositorio;
        this.repositorioConta = repositorioConta;
        this.repositorioAporte = repositorioAporte;
    }

    public async Task<IList<ProdutoRendaFixa>> GetAllAsync()
    {
        log.LogInformation("Obtendo todos os produtos de renda fixa.");
        var resultado = await repositorio.GetAllAsync();
        return resultado;
    }

    public async Task<ProdutoRendaFixa> GetByIdAsync(int id) 
    {
        log.LogInformation($"Obtendo o produto de renda fixa com id {id}");
        var resultado = await repositorio.GetByIdAsync(id);
        return resultado;
    }
    //todo corrigir, adicionar o cancellation token
    public async Task ComprarAsync(int produtoId, int contaId, int quantidade)
    {
        var conta = await repositorioConta.GetByIdAsync(contaId);
        var produto = await repositorio.GetByIdAsync(produtoId);
        if(quantidade < produto.Estoque)
        {
            var calculo = produto.PrecoUnitario * quantidade;
            if(calculo < conta.Saldo)
            {
                conta.Saldo -= calculo;
                await repositorioConta.UpdateAsync(conta);

                var entidade = new Aporte(produtoId, contaId, DateTime.Now, 1);
                await repositorioAporte.InsertAsync(entidade);

                produto.Estoque -= quantidade;
                await repositorio.UpdateAsync(produto);
            }
        }
    }
    public async Task<Conta> GetContaAsync(int contaId)
    {
        return await repositorioConta.GetByIdAsync(contaId);
    }
}