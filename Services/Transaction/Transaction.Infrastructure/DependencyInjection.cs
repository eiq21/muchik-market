using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Transaction.Application.Clock;
using Transaction.Domain.Transactions;
using Transaction.Infrastructure.Clock;
using Transaction.Infrastructure.Persistence;
using Transaction.Infrastructure.Persistence.Repositories;

namespace Transaction.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddTransactionInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services
        .AddTransactionServicePrivider()
        .AddTransactionPersistence();

        return services;
    }

    private static IServiceCollection AddTransactionServicePrivider(
        this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    public static IServiceCollection AddTransactionPersistence(
        this IServiceCollection services)
    {
        services.AddScoped<ITransactionRepository, TransactionRepository>();
        services.AddSingleton<TransactionDbContext>();


        return services;
    }
}
