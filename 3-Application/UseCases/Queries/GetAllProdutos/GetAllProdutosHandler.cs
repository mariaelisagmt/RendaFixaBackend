using AutoMapper;
using MediatR;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.Service.UseCases.Queries.GetAllProdutos;

public class GetAllProdutosHandler : IRequestHandler<GetAllProdutosRequest, IList<GetAllProdutosResponse>>
{
    private readonly IProdutoRendaFixaRepository repository;
    private readonly IMapper mapper;

    public GetAllProdutosHandler(IProdutoRendaFixaRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<IList<GetAllProdutosResponse>> Handle(GetAllProdutosRequest request, CancellationToken cancellationToken)
    {
        var resposta = await repository.GetProdutosAsync(cancellationToken);

        return mapper.Map<IList<GetAllProdutosResponse>>(resposta);
    }
}
