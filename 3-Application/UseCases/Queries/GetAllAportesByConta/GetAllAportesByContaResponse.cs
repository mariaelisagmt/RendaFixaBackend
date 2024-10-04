namespace RendaFixa.Service.UseCases.Queries.GetAllAportesByConta;

public sealed record GetAllAportesByContaResponse(
    int Id,
    int RendaFixaId,
    DateTime DataOperacao,
    int Quantidade);

