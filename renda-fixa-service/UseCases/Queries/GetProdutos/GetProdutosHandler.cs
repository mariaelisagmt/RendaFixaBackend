using AutoMapper;
using MediatR;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.Service.UseCases.Queries.GetProdutos;

public class GetProdutosHandler : IRequestHandler<GetProdutosRequest, IList<GetProdutosResponse>>
{
    private readonly IProdutoRendaFixaRepository repository;
    private readonly IMapper mapper;

    public GetProdutosHandler(IProdutoRendaFixaRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<IList<GetProdutosResponse>> Handle(GetProdutosRequest request, CancellationToken cancellationToken)
    {
        var aporte = mapper.Map<ProdutoRendaFixa>(request);

        var resposta = await repository.GetProdutosAsync(cancellationToken);

        return mapper.Map<IList<GetProdutosResponse>>(resposta);
    }
}
