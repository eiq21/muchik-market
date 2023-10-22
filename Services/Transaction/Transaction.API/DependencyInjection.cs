namespace Transaction.API;
public static class DependencyInjection
{
    public static IServiceCollection AddTransactionPresentation(
        this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        return services;
    }
}
