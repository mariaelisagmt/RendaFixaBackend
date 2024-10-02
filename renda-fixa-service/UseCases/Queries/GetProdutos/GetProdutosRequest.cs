using MediatR;

namespace RendaFixa.Service.UseCases.Queries.GetProdutos;

public sealed record GetProdutosRequest() : IRequest<IList<GetProdutosResponse>>;