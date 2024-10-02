using AutoMapper;
using RendaFixa.Domain.Entities;

namespace RendaFixa.Service.UseCases.Queries.GetAllProdutos;

public sealed class GetAllProdutosMapper : Profile
{
    public GetAllProdutosMapper()
    {
        CreateMap<GetAllProdutosRequest, ProdutoRendaFixa>();
        CreateMap<ProdutoRendaFixa, GetAllProdutosResponse>();
    }
}
