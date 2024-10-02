namespace RendaFixa.Service.UseCases.Queries.GetProdutos;

public sealed record GetProdutosResponse(
        int id,
        string nome,
        string indexador,
        decimal precoUnitario,
        decimal taxa,
        int estoque);

