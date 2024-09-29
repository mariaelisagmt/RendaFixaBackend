using System.ComponentModel.DataAnnotations.Schema;

namespace RendaFixa.Domain.Entities;

public class Conta : BaseEntity
{
    [ForeignKey(nameof(Cliente.Id))]
    public int ClienteId { get; set; }
    public int CodigoConta { get; set; }
    public virtual Cliente Cliente { get; set; }
    public virtual IList<Aporte> Aportes { get; set; }

    public Conta(
        int id,
        int clienteId,
        int codigoConta)
    {
        Id = id;
        CodigoConta = codigoConta;
        ClienteId = clienteId;
    }
}
