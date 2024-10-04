using Bogus;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Test.Unitarios.Faker;

public class ContaFaker : Faker<Conta>
{
    public ContaFaker()
    {
        RuleFor(c => c.Id, f => f.Random.Int(1, 1000));
        RuleFor(c => c.ClienteId, f => f.Random.Int(1, 1000));
        RuleFor(c => c.Codigo, f => f.Random.Int(10000, 99999));
        RuleFor(c => c.Saldo, f => f.Finance.Amount(0, 10000));
    }
}
