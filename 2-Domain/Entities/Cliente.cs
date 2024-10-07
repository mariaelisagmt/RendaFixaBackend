namespace RendaFixa.Domain.Entities;

public class Cliente : BaseEntity
{
    public string Nome { get;  set; }
    public string CPF { get;  set; }
    public DateTime DataNascimento { get;  set; }
    public virtual IList<Conta> Contas { get;  set; }

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
