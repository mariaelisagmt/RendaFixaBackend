namespace RendaFixa.Domain.Entities;

public class Cliente : BaseEntity
{
    public string Nome { get; private set; }
    public string CPF { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public virtual IList<Conta> Contas { get; private set; }

    public Cliente() { }
    public Cliente(
        int id,
        string nome,
        string cPF,
        DateTime dataNascimento)
    {
        Id = id;
        Nome = nome;
        CPF = cPF;
        DataNascimento = dataNascimento;
    }
}
