using Microsoft.Extensions.DependencyInjection;

namespace Sale.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddSaleApplicacion(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });
        return services;
    }
}
