using System.ComponentModel.DataAnnotations.Schema;

namespace RendaFixa.Domain.Entities;

public class Conta : BaseEntity
{
    [ForeignKey(nameof(Cliente.Id))]
    public int ClienteId { get; private set; }
    public int Codigo { get; private set; }
    public decimal Saldo { get; private set; }
    public virtual Cliente Cliente { get; private set; }
    public virtual IList<Aporte> Aportes { get; private set; }

    public Conta() { }

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

    public void Debitar(decimal valor)
    {
        Saldo -= valor;
    }

    public void Creditar(decimal valor)
    {
        Saldo += valor;
    }
}
