using MediatR;

namespace RendaFixa.Service.UseCases.Queries.GetAllProdutos;

public sealed record GetAllProdutosRequest() : IRequest<IList<GetAllProdutosResponse>>;