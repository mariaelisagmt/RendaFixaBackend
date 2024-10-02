using AutoMapper;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Service.UseCases.Queries.GetContaById;

public sealed class GetContaByIdMapper : Profile
{
    public GetContaByIdMapper()
    {
        CreateMap<GetContaByIdRequest, Conta>();
        CreateMap<Conta, GetContaByIdResponse>();
    }
}
