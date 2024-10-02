using MediatR;
using Microsoft.AspNetCore.Mvc;
using RendaFixa.Service.UseCases.Queries.GetContaById;

namespace RendaFixa.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContaController : ControllerBase
{
    private readonly IMediator mediator;
    public ContaController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<GetContaByIdResponse>> GetById(GetContaByIdRequest request, CancellationToken cancellationToken)
    {
        var validador = new GetContaByIdValidator();
        var validadorResultado = await validador.ValidateAsync(request, cancellationToken);

        if (!validadorResultado.IsValid)
        {
            return BadRequest(validadorResultado.Errors);
        }

        var resposta = await mediator.Send(request, cancellationToken);
        return Ok(resposta);
    }
}
