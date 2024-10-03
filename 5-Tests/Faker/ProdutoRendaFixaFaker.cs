using Bogus;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Test.Unitarios.Faker;

public class ProdutoRendaFixaFaker : Faker<ProdutoRendaFixa>
{
    public ProdutoRendaFixaFaker()
    {
        RuleFor(p => p.Id, f => f.Random.Int(1, 10000)); 
        RuleFor(p => p.Nome, f => f.Commerce.ProductName()); 
        RuleFor(p => p.Indexador, f => f.Random.Word()); 
        RuleFor(p => p.PrecoUnitario, f => f.Finance.Amount(10, 5000));
        RuleFor(p => p.Taxa, f => f.Finance.Amount(0, 100));
        RuleFor(p => p.Estoque, f => f.Random.Int(0, 1000));
    }
}
