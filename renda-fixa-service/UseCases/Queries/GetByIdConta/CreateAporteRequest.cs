using MediatR;

namespace RendaFixa.Service.UseCases.Queries.GetAllProdutoRendaFixa;

public sealed record GetAllAportesByContaRequest(int ContaId, int ProdutoId, int Quantidade) : IRequest<CreateAporteResponse>;

