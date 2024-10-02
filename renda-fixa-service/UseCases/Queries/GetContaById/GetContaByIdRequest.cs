using MediatR;

namespace RendaFixa.Service.UseCases.Queries.GetContaById;

public sealed record GetContaByIdRequest(int ContaId) : IRequest<GetContaByIdResponse>;