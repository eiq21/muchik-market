using Microsoft.Extensions.DependencyInjection;

namespace Transaction.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddTransactionApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
       {
           configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
       });

        return services;
    }
}
