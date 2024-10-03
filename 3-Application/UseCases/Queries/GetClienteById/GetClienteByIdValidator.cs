using FluentValidation;

namespace RendaFixa.Service.UseCases.Queries.GetClienteById;

public sealed class GetClienteByIdValidator : AbstractValidator<GetClienteByIdRequest>
{
    public GetClienteByIdValidator()
    {
        RuleFor(x => x.ClienteId).NotEmpty();
    }
}