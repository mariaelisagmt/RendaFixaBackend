namespace RendaFixa.Service.UseCases.Queries.GetAllAportesByConta;

public sealed record GetAllAportesByContaResponse(
        int rendaFixaId,
        DateTime dataOperacao,
        int status);

