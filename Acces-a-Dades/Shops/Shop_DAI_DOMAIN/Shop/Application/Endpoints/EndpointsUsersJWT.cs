using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
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
                role: client.Role,
                audience: "public",
                lifetime: TimeSpan.FromHours(2)
            );

            return Results.Ok(new { token, user = client });
        });


        app.MapPost("/debug/token", (TokenRequest request, JswTokenService jwtService) =>
        {
            if (request == null || string.IsNullOrEmpty(request.Token))
                return Results.BadRequest(new { message = "Token is required" });

            try
            {
                var claims = jwtService.ValidateAndGetClaimsFromToken(request.Token);
                var decodedClaims = claims.Select(c => new { c.Type, c.Value }).ToList();
                return Results.Ok(new { valid = true, claims = decodedClaims });
            }
            catch (SecurityTokenExpiredException)
            {
                return Results.Unauthorized();
            }
            catch (SecurityTokenException)
            {
                return Results.BadRequest(new { message = "Token invalid or manipulated" });
            }
        });
    }
}

public record LoginRequest(string DNI);
public record TokenRequest(string Token);