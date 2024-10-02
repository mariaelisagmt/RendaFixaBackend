using MediatR;

namespace RendaFixa.Service.UseCases.Queries.GetAllAportesByConta;

public sealed record GetAllAportesByContaRequest(int ContaId) : IRequest<IList<GetAllAportesByContaResponse>>;

