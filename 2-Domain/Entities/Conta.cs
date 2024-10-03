using System.ComponentModel.DataAnnotations.Schema;

namespace RendaFixa.Domain.Entities;

public class Conta : BaseEntity
{
    [ForeignKey(nameof(Cliente.Id))]
    public int ClienteId { get; set; }
    public int Codigo { get; set; }
    public decimal Saldo { get; set; }
    public virtual Cliente Cliente { get; set; }
    public virtual IList<Aporte> Aportes { get; set; }

    public Conta(
        int id,
        int clienteId,
        decimal saldo,
        int codigo)
    {
        Id = id;
        Codigo = codigo;
        Saldo = saldo;
        ClienteId = clienteId;
    }
}
