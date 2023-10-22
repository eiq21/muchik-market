using EventBus;
using EventBus.Settings;
using Sale.API;
using Sale.Application;
using Sale.Application.Features.Invoices.Events;
using Sale.Infrastructure;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);
{
    // builder.AddConfigServer();
    builder.Services.AddDiscoveryClient();

    //Event & EventHandlers
    builder.Services.AddTransient<IEventHandler<PayedInvoiceEvent>, PayedInvoiceEventHandler>();
    builder.Services.AddTransient<PayedInvoiceEventHandler>();


    builder.Services.Configure<RabbitMqSettings>(builder.Configuration.GetSection("RabbitMqSettings"));
    builder.Services.AddRabbitServices();



    builder.Services
    .AddSalePresentation()
    .AddSaleApplicacion()
    .AddSaleInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    var eventBus = app.Services.GetRequiredService<IEventBus>();
    eventBus.Subscribe<PayedInvoiceEvent, PayedInvoiceEventHandler>();


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


