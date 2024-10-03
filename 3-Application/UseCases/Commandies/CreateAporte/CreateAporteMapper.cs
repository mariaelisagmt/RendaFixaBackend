using AutoMapper;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Service.UseCases.Commandies.CreateAporte;

public sealed class CreateAporteMapper : Profile
{
    public CreateAporteMapper()
    {
        CreateMap<CreateAporteRequest, Aporte>();
        CreateMap<Aporte, CreateAporteResponse>();
    }
}
