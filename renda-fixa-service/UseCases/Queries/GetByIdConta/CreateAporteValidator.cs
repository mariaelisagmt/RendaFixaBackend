using FluentValidation;

namespace RendaFixa.Service.UseCases.Queries.GetAllProdutoRendaFixa;

public sealed class GetAllAportesByContaValidator : AbstractValidator<GetAllAportesByContaRequest>
{
    public GetAllAportesByContaValidator()
    {
        RuleFor(x => x.ContaId).NotEmpty();
        RuleFor(x => x.ProdutoId).NotEmpty();
        RuleFor(x => x.Quantidade).NotEmpty().GreaterThanOrEqualTo(1);
    }
}