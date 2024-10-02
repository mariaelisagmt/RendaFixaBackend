using MediatR;
using Microsoft.AspNetCore.Mvc;
using RendaFixa.Service.UseCases.Queries.GetClienteById;

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

    [HttpGet]
    public async Task<ActionResult<GetClienteByIdResponse>> GetById(GetClienteByIdRequest request, CancellationToken cancellationToken)
    {
        var validador = new GetClienteByIdValidator();
        var validadorResultado = await validador.ValidateAsync(request, cancellationToken);

        if (!validadorResultado.IsValid)
        {
            return BadRequest(validadorResultado.Errors);
        }

        var resposta = await mediator.Send(request, cancellationToken);
        return Ok(resposta);
    }
}
