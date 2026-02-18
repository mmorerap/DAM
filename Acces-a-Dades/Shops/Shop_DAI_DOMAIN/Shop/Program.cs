using Microsoft.Extensions.Configuration;
using dbdemo.Services;
using dbdemo.Endpoints;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddScoped<JswTokenService>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(builder.Configuration["Jwt:JwtSecretKey"]!)
                ),
            ValidateIssuer = true,
            ValidIssuer = "demo",
            ValidateAudience = true,
            ValidAudience = "public",
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30)
        };
    });

builder.Services.AddAuthorization();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
DatabaseConnection dbConn = new DatabaseConnection(connectionString);

WebApplication webApp = builder.Build();

webApp.UseRouting();
webApp.UseAuthentication();
webApp.UseAuthorization();

webApp.MapProductEndpoints(dbConn);
webApp.MapFamiliaEndpoints(dbConn);
webApp.MapCarritoComprasEndpoints(dbConn);
webApp.MapCarritoProducteEndpoints(dbConn);

// ✅ Ya no pasamos jwtService como parámetro
webApp.MapUserEndpointsJWT(dbConn);

webApp.Run();