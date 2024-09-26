namespace renda_fixa_dominio.Entidades;

public class Conta
{
    public Guid Id { get; set; }
    public int CodigoConta { get; set; }
    public Guid ClienteId { get; set; }
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
