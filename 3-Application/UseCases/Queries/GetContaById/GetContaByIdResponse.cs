namespace RendaFixa.Service.UseCases.Queries.GetContaById;

public sealed record GetContaByIdResponse(
    int Id,
    int Codigo,
    int ClienteId,
    decimal Saldo);

