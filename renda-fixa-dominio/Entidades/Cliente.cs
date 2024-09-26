namespace renda_fixa_dominio.Entidades;

public class Cliente
{

    public Guid Id { get; set; }
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
