namespace Payment.API;
public static class DependencyInjection
{
    public static IServiceCollection AddPaymentPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}

