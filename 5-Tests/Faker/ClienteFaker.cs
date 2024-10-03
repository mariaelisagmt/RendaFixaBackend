using Bogus;
using Bogus.Extensions.Brazil;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Test.Unitarios.Faker;

public class ClienteFaker : Faker<Cliente>
{
    public ClienteFaker()
    {
        RuleFor(c => c.Id, f => f.Random.Int(1, 1000));
        RuleFor(c => c.Nome, f => f.Name.FullName());
        RuleFor(c => c.CPF, f => f.Person.Cpf());
        RuleFor(c => c.DataNascimento, f => f.Date.Past(30, DateTime.Now.AddYears(-18)));
    }
}