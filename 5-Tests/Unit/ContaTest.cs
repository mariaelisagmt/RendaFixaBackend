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
public class ContaServiceTests
{
    private Mock<AppDbContext> contextMock;
    private Mock<DbSet<Conta>> contaMock;
    private IContaRepository repository;
    private CancellationToken cancellationToken;

    [SetUp]
    public void SetUp()
    {
        contextMock = new Mock<AppDbContext>();
        contaMock = new Mock<DbSet<Conta>>();
        cancellationToken = new CancellationToken();

        contextMock.Setup(c => c.Set<Conta>()).Returns(contaMock.Object);
        repository = new ContaRepository(contextMock.Object);
    }

    [Test]
    public async Task GetByIdAsync_ReturnsConta_WhenContaExists()
    {
        // Arrange
        var contaEsperada = new ContaFaker().Generate();

        contaMock.Setup(m => m.FindAsync(contaEsperada.Id, cancellationToken))
                  .ReturnsAsync(contaEsperada);

        // Act
        var result = await repository.GetByIdAsync(contaEsperada.Id);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(contaEsperada.Id);
        result.Codigo.Should().Be(contaEsperada.Codigo);
        result.Saldo.Should().Be(contaEsperada.Saldo);
    }
}