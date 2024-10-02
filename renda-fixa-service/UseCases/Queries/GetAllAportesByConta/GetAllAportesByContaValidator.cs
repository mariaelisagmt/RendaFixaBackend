using FluentValidation;

namespace RendaFixa.Service.UseCases.Queries.GetAllAportesByConta;

public sealed class GetAllAportesByContaValidator : AbstractValidator<GetAllAportesByContaRequest>
{
    public GetAllAportesByContaValidator()
    {
        RuleFor(x => x.ContaId).NotEmpty();
    }
}