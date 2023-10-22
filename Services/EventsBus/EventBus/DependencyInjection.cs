using System.Reflection;
using EventBus.Settings;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EventBus;
public static class DependencyInjection
{
    public static IServiceCollection AddRabbitServices(
        this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
      {
          configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
      });
        services.AddSingleton<IEventBus, RabbitMqBus>(config =>
        {
            var mediatorFactory = config.GetService<IMediator>();
            var scopeFactory = config.GetRequiredService<IServiceScopeFactory>();
            var optionsFactory = config.GetService<IOptions<RabbitMqSettings>>();
            return new RabbitMqBus(mediatorFactory, scopeFactory, optionsFactory);
        });

        return services;
    }
}
