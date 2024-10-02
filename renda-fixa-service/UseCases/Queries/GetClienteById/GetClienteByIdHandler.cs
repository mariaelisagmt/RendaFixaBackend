using AutoMapper;
using MediatR;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;

namespace RendaFixa.Service.UseCases.Queries.GetClienteById;

public class GetClienteByIdHandler : IRequestHandler<GetClienteByIdRequest, GetClienteByIdResponse>
{
    private readonly IClienteRepository repository;
    private readonly IMapper mapper;

    public GetClienteByIdHandler(IClienteRepository repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<GetClienteByIdResponse> Handle(GetClienteByIdRequest request, CancellationToken cancellationToken)
    {

        var resposta = await repository.GetByIdAsync(request.ClienteId, cancellationToken);

        return mapper.Map<GetClienteByIdResponse>(resposta);
    }
}
