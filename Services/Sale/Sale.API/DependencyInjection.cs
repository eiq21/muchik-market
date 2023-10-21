namespace Sale.API;

public static class DependencyInjection
{
    public static IServiceCollection AddSalePresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}
