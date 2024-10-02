using AutoMapper;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Service.UseCases.Queries.GetProdutos;

public sealed class GetProdutosMapper : Profile
{
    public GetProdutosMapper()
    {
        CreateMap<GetProdutosRequest, ProdutoRendaFixa>();
        CreateMap<ProdutoRendaFixa, GetProdutosResponse>();
    }
}
