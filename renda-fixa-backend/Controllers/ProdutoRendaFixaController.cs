using MediatR;
using Microsoft.AspNetCore.Mvc;
using RendaFixa.Service.UseCases.Queries.GetAllProdutos;

namespace RendaFixaBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoRendaFixaController : ControllerBase
{
    private readonly IMediator mediator;

    public ProdutoRendaFixaController(
        IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<GetAllProdutosResponse>> GetAll(CancellationToken cancellationToken)
    {
        var request = new GetAllProdutosRequest();
        var resposta = await mediator.Send(request, cancellationToken);
        return Ok(resposta);
    }
}
