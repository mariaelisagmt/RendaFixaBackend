using AutoMapper;
using MediatR;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.Service.UseCases.Queries.GetAllAportesByConta;

public class GetAllAportesByContaHandler : IRequestHandler<GetAllAportesByContaRequest, IList<GetAllAportesByContaResponse>>
{
    private readonly IAporteRepository aporteRepository;
    private readonly IMapper mapper;

    public GetAllAportesByContaHandler(IAporteRepository aporteRepository, IMapper mapper)
    {
        this.aporteRepository = aporteRepository;
        this.mapper = mapper;
    }

    public async Task<IList<GetAllAportesByContaResponse>> Handle(GetAllAportesByContaRequest request, CancellationToken cancellationToken)
    {
        var resultado = await aporteRepository.GetAllByContaAsync(request.ContaId, cancellationToken);

        return resultado.Select(x => mapper.Map<GetAllAportesByContaResponse>(x)).ToList();
    }
}
