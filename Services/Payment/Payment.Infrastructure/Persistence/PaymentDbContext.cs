using Microsoft.EntityFrameworkCore;
using Payment.Application.Exceptions;
using Payment.Domain.Abstractions;
using Payment.Domain.Payments;

namespace Payment.Infrastructure.Persistence;
public class PaymentDbContext : DbContext, IUnitOfWork
{
    public PaymentDbContext(DbContextOptions<PaymentDbContext> options)
    : base(options)
    {

    }

    public DbSet<Domain.Payments.Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PaymentDbContext).Assembly);

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
            throw new ConcurrencyException("Concurrency exception ocurred.", ex);
        }
    }
}
