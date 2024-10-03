using MediatR;
using Microsoft.AspNetCore.Mvc;
using RendaFixa.Service.UseCases.Queries.GetClienteById;

namespace RendaFixaBackend.Controllers;

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
    public async Task<ActionResult<GetClienteByIdResponse>> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new GetClienteByIdRequest(id);

        var resposta = await mediator.Send(request, cancellationToken);
        return Ok(resposta);
    }
}
