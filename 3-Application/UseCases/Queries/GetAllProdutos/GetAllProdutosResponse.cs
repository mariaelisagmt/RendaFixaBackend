namespace RendaFixa.Service.UseCases.Queries.GetAllProdutos;

public sealed record GetAllProdutosResponse(
        int Id,
        string Nome,
        string Indexador,
        decimal PrecoUnitario,
        decimal Taxa,
        int Estoque);

