using MediatR;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Service.UseCases.Queries.GetAllProdutoRendaFixa;

public sealed record CreateAporteResponse(int AporteId, int Status);

