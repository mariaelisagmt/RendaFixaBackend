namespace renda_fixa_dominio.Entidades;

public class RendaFixa
{
    public Guid Id { get; set; }
    public string Nome {  get; set; }
    public string Indexador { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal Taxa {  get; set; }
    public int Estoque {  get; set; }
    public RendaFixa(
        Guid id,
        string nome,
        string indexador,
        decimal precoUnitario,
        decimal taxa,
        int estoque)
    {
        Id = id;
        Nome = nome;
        Indexador = indexador;
        PrecoUnitario = precoUnitario;
        Taxa = taxa;
        Estoque = estoque;
    }
}
