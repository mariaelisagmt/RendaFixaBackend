using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;
using RendaFixa.Infrastruct.Context;
using RendaFixa.Infrastruct.Repositories;
using RendaFixa.Test.Unitarios.Faker;

namespace RendaFixa.Test.Unit;

[TestFixture]
public class ProdutoRendaFixaServiceTests
{
    private Mock<AppDbContext> contextMock;
    private Mock<DbSet<ProdutoRendaFixa>> produtoMock;
    private IProdutoRendaFixaRepository repository;
    private Mock<ILogger<ProdutoRendaFixaRepository>> loggerMock;
    private CancellationToken cancellationToken;

    [SetUp]
    public void SetUp()
    {
        contextMock = new Mock<AppDbContext>();
        produtoMock = new Mock<DbSet<ProdutoRendaFixa>>();
        contextMock.Setup(c => c.Set<ProdutoRendaFixa>()).Returns(produtoMock.Object);
        cancellationToken = new CancellationToken();
        loggerMock = new Mock<ILogger<ProdutoRendaFixaRepository>>();
    }

    [Test]
    public async Task GetByAllAsync_ReturnsProdutos_WhenProdutoExists()
    {
        // Arrange
        var listaEsperada = new ProdutoRendaFixaFaker().Generate(25).AsQueryable();

        produtoMock.As<IQueryable<ProdutoRendaFixa>>()
            .Setup(m => m.Provider)
            .Returns(listaEsperada.Provider);
        produtoMock.As<IQueryable<ProdutoRendaFixa>>()
            .Setup(m => m.Expression)
            .Returns(listaEsperada.Expression);
        produtoMock.As<IQueryable<ProdutoRendaFixa>>()
            .Setup(m => m.ElementType)
            .Returns(listaEsperada.ElementType);
        produtoMock.As<IQueryable<ProdutoRendaFixa>>()
            .Setup(m => m.GetEnumerator())
            .Returns(listaEsperada.GetEnumerator());


        produtoMock.Setup(m => m.ToListAsync(cancellationToken))
                  .ReturnsAsync(listaEsperada.OrderByDescending(x => x.Taxa).ToList());

        repository = new ProdutoRendaFixaRepository(contextMock.Object, loggerMock.Object);

        // Act
        var result = await repository.GetProdutosAsync(cancellationToken);

        // Assert
        result.Should().NotBeNull();
    }
}