namespace RendaFixa.Domain.Entities;

public class Aporte : BaseEntity
{
    public int RendaFixaId { get; private set; }
    public int ContaId { get; private set; }
    public DateTime DataOperacao { get; private set; }
    public int Quantidade { get; private set; }
    public virtual ProdutoRendaFixa RendaFixa { get; private set; }
    public virtual Conta Conta { get; private set; }

    public Aporte() { }
    public Aporte(
        int rendaFixaId,
        int contaId,
        DateTime dataOperacao,
        int quantidade)
    {
        RendaFixaId = rendaFixaId;
        ContaId = contaId;
        DataOperacao = dataOperacao;
        Quantidade = quantidade;
    }
}
