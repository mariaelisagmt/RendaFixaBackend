using Microsoft.AspNetCore.Mvc;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RendaFixaController : ControllerBase
{
    private readonly IProdutoRendaFixaService service;

    public RendaFixaController(
        IProdutoRendaFixaService servico)
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
    public async Task<IActionResult> GetById(Guid id)
    {
        var resultado = await service.GetByIdAsync(id);

        return Ok(resultado);
    }
}
