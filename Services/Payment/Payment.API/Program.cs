using Payment.API;
using Payment.Application;
using Payment.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
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

