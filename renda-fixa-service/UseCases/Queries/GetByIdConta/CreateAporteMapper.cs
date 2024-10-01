using AutoMapper;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Service.UseCases.Queries.GetAllProdutoRendaFixa;

public sealed class GetAllAportesByContaMapper : Profile
{
    public GetAllAportesByContaMapper()
    {
        CreateMap<GetAllAportesByContaRequest, Aporte>();
        CreateMap<Aporte, CreateAporteResponse>();
    }
}
