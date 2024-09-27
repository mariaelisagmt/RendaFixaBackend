namespace RendaFixa.Domain.Entities;

public class Conta : BaseEntity
{
    public Guid ClienteId { get; set; }
    public int CodigoConta { get; set; }
    public Cliente Cliente { get; set; }

    public Conta(
        Guid id,
        Guid clienteId,
        int codigoConta)
    {
        Id = id;
        CodigoConta = codigoConta;
        ClienteId = clienteId;
    }
}
