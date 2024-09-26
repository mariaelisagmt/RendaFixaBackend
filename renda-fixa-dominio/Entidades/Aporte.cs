namespace renda_fixa_dominio.Entidades;

public class Aporte
{

    public Guid Id { get; set; }
    public Guid RendaFixaId { get; set; }
    public Guid ContaId { get; set; }
    public DateTime DataCompra { get; set; }
    public Status Status { get; set; }
    public virtual RendaFixa RendaFixa { get; set; }
    public virtual Conta Conta { get; set; }
    public Aporte(
        Guid id,
        Guid rendaFixaId,
        Guid contaId,
        DateTime dataCompra,
        Status status)
    {
        Id = id;
        RendaFixaId = rendaFixaId;
        ContaId = contaId;
        DataCompra = dataCompra;
        Status = status;
    }
}
