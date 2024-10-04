using MediatR;

namespace RendaFixa.Service.UseCases.Commandies.CreateAporte;

public sealed record CreateAporteRequest(int ContaId, int ProdutoId, int Quantidade) : IRequest;

