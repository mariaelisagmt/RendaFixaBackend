using Bogus;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Test.Unitarios.Faker;
public class AporteFaker : Faker<Aporte>
{
    public AporteFaker()
    {
        RuleFor(c => c.Id, f => f.Random.Int(1, 1000));
        RuleFor(a => a.RendaFixaId, f => f.Random.Int(1, 1000));
        RuleFor(a => a.ContaId, f => f.Random.Int(1, 1000));
        RuleFor(a => a.DataOperacao, f => f.Date.Past(2));
        RuleFor(a => a.Status, f => f.PickRandom(0, 1));
    }
}
