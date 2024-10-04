using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;
using RendaFixa.Infrastruct.Context;
using RendaFixa.Infrastruct.Repositories;
using RendaFixa.Test.Unitarios.Faker;

namespace RendaFixa.Test.Unit;

[TestFixture]
public class ClienteServiceTests
{
    private Mock<AppDbContext> contextMock;
    private Mock<DbSet<Cliente>> clienteMock;
    private IClienteRepository repository;
    private CancellationToken cancellationToken;

    [SetUp]
    public void SetUp()
    {
        contextMock = new Mock<AppDbContext>();
        clienteMock = new Mock<DbSet<Cliente>>();
        cancellationToken = new CancellationToken();

        contextMock.Setup(c => c.Set<Cliente>()).Returns(clienteMock.Object);
        repository = new ClienteRepository(contextMock.Object);
    }

    [Test]
    public async Task GetByIdAsync_ReturnsCliente_WhenClienteExists()
    {
        // Arrange
        var clienteEsperada = new ClienteFaker().Generate();

        clienteMock.Setup(m => m.FindAsync(clienteEsperada.Id, cancellationToken))
                  .ReturnsAsync(clienteEsperada);

        // Act
        var result = await repository.GetByIdAsync(clienteEsperada.Id);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(clienteEsperada.Id);
        result.Nome.Should().Be(clienteEsperada.Nome);
        result.CPF.Should().Be(clienteEsperada.CPF);
        result.DataNascimento.Should().Be(clienteEsperada.DataNascimento);
    }
}