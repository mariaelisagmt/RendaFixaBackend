using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RendaFixa.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClienteController : ControllerBase
{
    private readonly IMediator mediator;

    public ClienteController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById([FromRoute]int id)
    {
        var resultado = await service.GetByIdAsync(id);

        return Ok(resultado);
    }
}
