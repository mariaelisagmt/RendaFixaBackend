using AutoMapper;
using MediatR;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.Aplication.UseCases;

public class CreateAporteHandler : IRequestHandler<CreateAporteRequest, CreateAporteResponse>
{
    private readonly IAporteRepository aporteRepository;//Colocar o i service 
    private readonly IMapper mapper;

    public CreateAporteHandler(IAporteRepository aporteRepository, IMapper mapper)
    {
        this.aporteRepository = aporteRepository;
        this.mapper = mapper;
    }

    public async Task<CreateAporteResponse> Handle(CreateAporteRequest request, CancellationToken cancellationToken)
    {
        var aporte = mapper.Map<Aporte>(request);

        await aporteRepository.InsertAsync(aporte, cancellationToken);

        return mapper.Map<CreateAporteResponse>(aporte);
    }
}
