using RendaFixa.Domain.Enum;

namespace RendaFixa.Domain.Entities;

public class Aporte : BaseEntity
{
    public Guid RendaFixaId { get; set; }
    public Guid ContaId { get; set; }
    public DateTime DataOperacao { get; set; }
    public Status Status { get; set; }
    public virtual ProdutoRendaFixa RendaFixa { get; set; }
    public virtual Conta Conta { get; set; }
    public Aporte(
        Guid id,
        Guid rendaFixaId,
        Guid contaId,
        DateTime dataOperacao,
        Status status)
    {
        Id = id;
        RendaFixaId = rendaFixaId;
        ContaId = contaId;
        DataOperacao = dataOperacao;
        Status = status;
    }
}
