using AutoMapper;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Service.UseCases.Queries.GetAllAportesByConta;

public sealed class GetAllAportesByContaMapper : Profile
{
    public GetAllAportesByContaMapper()
    {
        CreateMap<GetAllAportesByContaRequest, Aporte>();
        CreateMap<Aporte, GetAllAportesByContaResponse>();
    }
}
