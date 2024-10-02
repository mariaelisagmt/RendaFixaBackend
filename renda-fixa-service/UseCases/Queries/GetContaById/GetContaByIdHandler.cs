using AutoMapper;
using MediatR;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.Service.UseCases.Queries.GetContaById;

public class GetContaByIdHandler : IRequestHandler<GetContaByIdRequest, GetContaByIdResponse>
{
    private readonly IContaRepository repository;
    private readonly IMapper mapper;

    public GetContaByIdHandler(IContaRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<GetContaByIdResponse> Handle(GetContaByIdRequest request, CancellationToken cancellationToken)
    {
        var aporte = mapper.Map<Conta>(request);

        var resposta = await repository.GetByIdAsync(request.ContaId, cancellationToken);

        return mapper.Map<GetContaByIdResponse>(resposta);
    }
}
