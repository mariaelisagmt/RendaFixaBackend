using MediatR;

namespace RendaFixa.Service.UseCases.Queries.GetClienteById;

public sealed record GetClienteByIdRequest(int ClienteId) : IRequest<GetClienteByIdResponse>;