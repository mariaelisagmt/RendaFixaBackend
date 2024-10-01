using Microsoft.AspNetCore.Mvc;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContaFixaController : ControllerBase
{
    private readonly IProdutoRendaFixaRepository service;

    public ProdutoRendaFixaController(
        IProdutoRendaFixaRepository servico)
    {
        service = servico;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var resultado = await service.GetAllAsync();

        return Ok(resultado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute]int id)
    {
        var resultado = await service.GetByIdAsync(id);

        return Ok(resultado);
    }

    [HttpGet("{contaid}")]
    public async Task<IActionResult> GetContaById([FromRoute]int contaid)
    {
        var resultado = await service.GetContaAsync(contaid);

        return Ok(resultado);
    }

    [HttpPost]
    public async Task<IActionResult> Comprar(int produtoId, int contaId, int qtd)
    {
        await service.ComprarAsync(produtoId, contaId, qtd);

        return Ok();
    }

}
