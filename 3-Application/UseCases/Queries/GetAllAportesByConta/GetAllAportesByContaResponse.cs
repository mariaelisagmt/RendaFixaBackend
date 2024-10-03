namespace RendaFixa.Service.UseCases.Queries.GetAllAportesByConta;

public sealed record GetAllAportesByContaResponse(
    int RendaFixaId,
    DateTime DataOperacao,
    int Status);

