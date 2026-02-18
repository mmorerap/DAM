using System.Security.Claims;
using dbdemo.Services;
using dbdemo.Repository;
using dbdemo.DTO;
using dbdemo.Model;

namespace dbdemo.Endpoints;

public static class EndpointsUserJWT
{
    public static void MapUserEndpointsJWT(this WebApplication app, DatabaseConnection dbConn)
    {
        app.MapPost("/login", (LoginRequest request, JswTokenService jwtService) =>
        {
            if (request == null || string.IsNullOrEmpty(request.DNI))
                return Results.BadRequest(new { message = "DNI is required" });

            ClientResponseJWT? client = JWTADO.GetByDNI(dbConn, request.DNI);

            if (client == null)
                return Results.Unauthorized();

            string token = jwtService.GenerateToken(
                userId: client.Id.ToString(),
                email: client.Nom,
                issuer: "demo",
                roles: client.Roles,
                audience: "public",
                lifetime: TimeSpan.FromHours(2)
            );

            return Results.Ok(new { token, user = client });
        });
    }
}

public record LoginRequest(string DNI);
public record TokenRequest(string Token);
