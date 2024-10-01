using FluentValidation;

namespace RendaFixa.Service.UseCases.Commandies.CreateAporte;

public sealed class CreateAporteValidator : AbstractValidator<CreateAporteRequest>
{
    public CreateAporteValidator()
    {
        RuleFor(x => x.ContaId).NotEmpty();
        RuleFor(x => x.ProdutoId).NotEmpty();
        RuleFor(x => x.Quantidade).NotEmpty().GreaterThanOrEqualTo(1);
    }
}