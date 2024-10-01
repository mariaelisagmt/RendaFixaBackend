using MediatR;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Service.UseCases.Commandies.CreateAporte;

public sealed record CreateAporteResponse(int AporteId, int Status);

