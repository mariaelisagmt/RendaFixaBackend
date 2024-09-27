namespace RendaFixa.Domain.Entities;

public class Cliente : BaseEntity
{
    public string Nome { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public Cliente(
        Guid id,
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
