using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Payment.Application.Clock;
using Payment.Domain.Abstractions;
using Payment.Domain.Payments;
using Payment.Infrastructure.Clock;
using Payment.Infrastructure.Persistence;
using Payment.Infrastructure.Persistence.Repositories;

namespace Payment.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddPaymentInfrastructure(
        this IServiceCollection services, IConfiguration configuration
        )
    {
        services
        .AddPaymentServicePrivider()
        .AddPaymentPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddPaymentServicePrivider(
        this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    private static IServiceCollection AddPaymentPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<PaymentDbContext>(options =>
        {
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<PaymentDbContext>());

        services.AddScoped<IPaymentRepository, PaymentRepository>();

        return services;
    }

}
