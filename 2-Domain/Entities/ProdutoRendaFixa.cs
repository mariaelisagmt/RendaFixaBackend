namespace RendaFixa.Domain.Entities;

public class ProdutoRendaFixa : BaseEntity
{
    public string Nome { get; private set; }
    public string Indexador { get; private set; }
    public decimal PrecoUnitario { get; private set; }
    public decimal Taxa { get; private set; }
    public int Estoque { get; private set; }
    public virtual IList<Aporte> Aportes { get; private set; }

    public ProdutoRendaFixa() { }
    public ProdutoRendaFixa(
        string nome,
        string indexador,
        decimal precoUnitario,
        decimal taxa,
        int estoque)
    {
        Nome = nome;
        Indexador = indexador;
        PrecoUnitario = precoUnitario;
        Taxa = taxa;
        Estoque = estoque;
    }

    public void ReporEstoque(int quantidade)
    {
        Estoque += quantidade;
    }

    public void BaixarEstoque(int quantidade)
    {
        Estoque -= quantidade;
    }
}
