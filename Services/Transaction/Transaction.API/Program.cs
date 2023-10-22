using Steeltoe.Discovery.Client;
using Transaction.API;
using Transaction.Application;
using Transaction.Infrastructure;
using Transaction.Infrastructure.Persistence.Settings;

var builder = WebApplication.CreateBuilder(args);
{
    // builder.AddConfigServer();
    builder.Services.AddDiscoveryClient();

    builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

    builder.Services
      .AddTransactionPresentation()
      .AddTransactionApplication()
      .AddTransactionInfrastructure(builder.Configuration);
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

