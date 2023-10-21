using Microsoft.EntityFrameworkCore;
using Sale.Application.Exceptions;
using Sale.Domain.Abstractions;
using Sale.Domain.Invoices;

namespace Sale.Infrastructure.Persistence;
public class SaleDbContext : DbContext, IUnitOfWork
{
    public SaleDbContext(DbContextOptions<SaleDbContext> options)
    : base(options)
    {

    }

    public DbSet<Invoice> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SaleDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("Concurrency exception occurred.", ex);
        }
    }

}
