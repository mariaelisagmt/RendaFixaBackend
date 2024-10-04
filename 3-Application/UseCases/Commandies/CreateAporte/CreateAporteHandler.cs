using AutoMapper;
using MediatR;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.Service.UseCases.Commandies.CreateAporte;

public class CreateAporteHandler : IRequestHandler<CreateAporteRequest>
{
    private readonly IAporteRepository aporteRepository;

    public CreateAporteHandler(IAporteRepository aporteRepository)
    {
        this.aporteRepository = aporteRepository;
    }

    public async Task Handle(CreateAporteRequest request, CancellationToken cancellationToken)
    {
        await aporteRepository.CreateAsync(request.ContaId, request.ProdutoId, request.Quantidade, cancellationToken);
    }
}
