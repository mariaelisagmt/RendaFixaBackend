using MediatR;
using Microsoft.AspNetCore.Mvc;
using RendaFixa.Service.UseCases.Commandies.CreateAporte;
using RendaFixa.Service.UseCases.Queries.GetAllAportesByConta;

namespace RendaFixaBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AporteController : ControllerBase
{
    private readonly IMediator mediator;

    public AporteController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<CreateAporteResponse>> Create(CreateAporteRequest request, CancellationToken cancellationToken)
    {
        var validador = new CreateAporteValidator();
        var validadorResultado = await validador.ValidateAsync(request, cancellationToken);

        if (!validadorResultado.IsValid)
        {
            return BadRequest(validadorResultado.Errors);
        }

        var resposta = await mediator.Send(request, cancellationToken);
        return Ok(resposta);
    }

    [HttpGet("{contaId}")]
    public async Task<ActionResult<CreateAporteResponse>> GetAllByConta([FromRoute] int contaId, CancellationToken cancellationToken)
    {
        var request = new GetAllAportesByContaRequest(contaId);

        var resposta = await mediator.Send(request, cancellationToken);
        return Ok(resposta);
    }
}
