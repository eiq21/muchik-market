using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sale.Application.Clock;
using Sale.Domain.Abstractions;
using Sale.Domain.Invoices;
using Sale.Infrastructure.Clock;
using Sale.Infrastructure.Persistence;
using Sale.Infrastructure.Persistence.Repositories;

namespace Sale.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddSaleInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {

        services
        .AddSaleServicePrivider()
        .AddSalePersistence(configuration);

        return services;
    }

    private static IServiceCollection AddSaleServicePrivider(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        return services;
    }

    private static IServiceCollection AddSalePersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SaleDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<SaleDbContext>());

        services.AddScoped<IInvoiceRepository, InvoiceRepository>();

        return services;
    }


}
