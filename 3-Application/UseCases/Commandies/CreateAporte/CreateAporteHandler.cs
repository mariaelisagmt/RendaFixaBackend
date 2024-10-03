using AutoMapper;
using MediatR;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.Service.UseCases.Commandies.CreateAporte;

public class CreateAporteHandler : IRequestHandler<CreateAporteRequest, CreateAporteResponse>
{
    private readonly IAporteRepository aporteRepository;
    private readonly IMapper mapper;

    public CreateAporteHandler(IAporteRepository aporteRepository, IMapper mapper)
    {
        this.aporteRepository = aporteRepository;
        this.mapper = mapper;
    }

    public async Task<CreateAporteResponse> Handle(CreateAporteRequest request, CancellationToken cancellationToken)
    {
        var resultado = await aporteRepository.CreateAsync(request.ContaId, request.ProdutoId, request.Quantidade, cancellationToken);

        return mapper.Map<CreateAporteResponse>(resultado);
    }
}
