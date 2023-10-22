using Payment.API;
using Payment.Application;
using Payment.Infrastructure;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);
{
    // builder.AddConfigServer();
    builder.Services.AddDiscoveryClient();

    builder.Services
     .AddPaymentPresentation()
     .AddPaymentApplication()
     .AddPaymentInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();

}

