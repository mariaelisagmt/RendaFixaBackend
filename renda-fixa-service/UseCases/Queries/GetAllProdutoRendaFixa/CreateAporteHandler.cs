using AutoMapper;
using MediatR;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.Service.UseCases.Queries.GetAllProdutoRendaFixa;

public class CreateAporteHandler : IRequestHandler<GetAllAportesByContaRequest, CreateAporteResponse>
{
    private readonly IAporteService service;

    public CreateAporteHandler(IAporteService service)
    {
        this.service = service;
    }

    public async Task<CreateAporteResponse> Handle(GetAllAportesByContaRequest request, CancellationToken cancellationToken)
    {
        var aporte = mapper.Map<Aporte>(request);

        await service.CreateAsync(aporte, cancellationToken);

        return mapper.Map<CreateAporteResponse>(aporte);
    }
}
