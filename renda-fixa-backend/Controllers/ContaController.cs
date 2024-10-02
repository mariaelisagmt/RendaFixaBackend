using MediatR;
using Microsoft.AspNetCore.Mvc;
using RendaFixa.Service.UseCases.Queries.GetContaById;

namespace RendaFixaBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContaController : ControllerBase
{
    private readonly IMediator mediator;
    public ContaController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetContaByIdResponse>> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new GetContaByIdRequest(id);

        var resposta = await mediator.Send(request, cancellationToken);
        return Ok(resposta);
    }
}
