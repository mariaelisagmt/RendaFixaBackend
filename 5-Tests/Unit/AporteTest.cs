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
public class AporteServiceTests
{
    private Mock<AppDbContext> contextMock;
    private Mock<DbSet<Aporte>> aporteMock;
    private IAporteRepository repository;
    private CancellationToken cancellationToken;

    [SetUp]
    public void SetUp()
    {
        contextMock = new Mock<AppDbContext>();
        aporteMock = new Mock<DbSet<Aporte>>();
        cancellationToken = new CancellationToken();

        contextMock.Setup(c => c.Set<Aporte>()).Returns(aporteMock.Object);
        //repository = new AporteRepository(contextMock.Object);
    }
}