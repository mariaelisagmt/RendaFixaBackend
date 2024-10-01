using MediatR;

namespace RendaFixa.Service.UseCases.Queries.GetAllProdutoRendaFixa;

public sealed record GetAllAportesByContaRequest(int ContaId) : IRequest<CreateAporteResponse>;

