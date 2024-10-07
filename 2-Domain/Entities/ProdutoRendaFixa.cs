namespace RendaFixa.Domain.Entities;

public class ProdutoRendaFixa : BaseEntity
{
    public string Nome { get;  set; }
    public string Indexador { get;  set; }
    public decimal PrecoUnitario { get;  set; }
    public decimal Taxa { get;  set; }
    public int Estoque { get;  set; }
    public virtual IList<Aporte> Aportes { get;  set; }

    public ProdutoRendaFixa() { }
    public ProdutoRendaFixa(
        int id,
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

    public void ReporEstoque(int quantidade)
    {
        Estoque += quantidade;
    }

    public void BaixarEstoque(int quantidade)
    {
        Estoque -= quantidade;
    }
}
