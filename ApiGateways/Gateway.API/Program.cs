using System.Text;
using Gateway.API.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Ocelot.Provider.Polly;
using Steeltoe.Extensions.Configuration.ConfigServer;

var builder = WebApplication.CreateBuilder(args);
{
    // builder.AddConfigServer();

    builder.Configuration
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

    builder.Services
        .AddOcelot()
        .AddPolly()
        .AddConsul();

    builder.Services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
      {
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
          ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
          ValidAudience = builder.Configuration["JwtSettings:Audience"],
          IssuerSigningKey = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Secret"])
           )
      });
}

var app = builder.Build();
{
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseMiddleware<AuthorizationMiddleware>();
    app.UseOcelot().Wait();
    app.Run();
}


