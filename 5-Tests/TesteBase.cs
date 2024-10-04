using Moq;
using Microsoft.EntityFrameworkCore;
using RendaFixa.Infrastruct.Context;

namespace RendaFixa.Test;

public class TestBase<TContext> where TContext : AppDbContext
{
    protected Mock<TContext> mockContext;

    [SetUp]
    public virtual void SetUp()
    {
        mockContext = new Mock<TContext>();
    }

    protected Mock<DbSet<TEntity>> CreateMockDbSet<TEntity>(IQueryable<TEntity> entities) where TEntity : class
    {
        var mockSet = new Mock<DbSet<TEntity>>();
        mockSet.As<IQueryable<TEntity>>().Setup(m => m.Provider).Returns(entities.Provider);
        mockSet.As<IQueryable<TEntity>>().Setup(m => m.Expression).Returns(entities.Expression);
        mockSet.As<IQueryable<TEntity>>().Setup(m => m.ElementType).Returns(entities.ElementType);
        mockSet.As<IQueryable<TEntity>>().Setup(m => m.GetEnumerator()).Returns(entities.GetEnumerator());

        return mockSet;
    }
}