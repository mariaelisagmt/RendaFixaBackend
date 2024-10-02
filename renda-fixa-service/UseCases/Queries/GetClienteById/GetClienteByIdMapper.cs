using AutoMapper;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Service.UseCases.Queries.GetClienteById;

public sealed class GetClienteByIdMapper : Profile
{
    public GetClienteByIdMapper()
    {
        CreateMap<GetClienteByIdRequest, Cliente>();
        CreateMap<Cliente, GetClienteByIdResponse>();
    }
}
