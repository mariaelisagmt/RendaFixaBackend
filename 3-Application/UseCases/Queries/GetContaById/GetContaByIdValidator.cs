using FluentValidation;

namespace RendaFixa.Service.UseCases.Queries.GetContaById;

public sealed class GetContaByIdValidator : AbstractValidator<GetContaByIdRequest>
{
    public GetContaByIdValidator()
    {
        RuleFor(x => x.ContaId).NotEmpty();
    }
}