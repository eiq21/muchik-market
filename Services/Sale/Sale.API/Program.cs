using Sale.API;
using Sale.Application;
using Sale.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
    .AddSalePresentation()
    .AddSaleApplicacion()
    .AddSaleInfrastructure(builder.Configuration);
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


