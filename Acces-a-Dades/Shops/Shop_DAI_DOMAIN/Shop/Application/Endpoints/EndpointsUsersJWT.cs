using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using dbdemo.Services;

namespace dbdemo.Endpoints;

public static class EndpointsUserJWT
{
    public static void MapUserEndpointsJWT(this WebApplication app)
    {
        // 🔐 LOGIN → Genera token
        app.MapPost("/login", (JswTokenService jwtService) =>
        {
            // ⚠️ Aquí normalmente validarías usuario contra BD
            // De momento lo dejamos fijo como en el ejemplo

            string token = jwtService.GenerateToken(
                userId: "1",
                email: "admin@demo.com",
                issuer: "demo",
                role: "admin",
                audience: "public",
                lifetime: TimeSpan.FromHours(2)
            );

            return Results.Ok(new { token });
        });

        // 🔎 DEBUG TOKEN (igual que el ejemplo que me pasaste)
        app.MapPost("/debug/token", (
            TokenRequest request,
            JswTokenService jwtService) =>
        {
            try
            {
                List<Claim> claims =
                    jwtService.ValidateAndGetClaimsFromToken(request.Token);

                List<object> decodedClaims = new();

                foreach (Claim claim in claims)
                {
                    decodedClaims.Add(new
                    {
                        type = claim.Type,
                        value = claim.Value
                    });
                }

                return Results.Ok(new
                {
                    valid = true,
                    claims = decodedClaims
                });
            }
            catch (SecurityTokenExpiredException)
            {
                return Results.Unauthorized();
            }
            catch (SecurityTokenException)
            {
                return Results.BadRequest("Token invalid or manipulated");
            }
        });

        // 🔒 Endpoint protegido manualmente (como en el ejemplo)
        app.MapGet("/admin-data-manual", (ClaimsPrincipal user) =>
        {
            if (!user.Identity?.IsAuthenticated ?? true)
                return Results.Unauthorized();

            bool isAdmin = user.Claims.Any(c =>
                c.Type == ClaimTypes.Role && c.Value == "admin");

            if (!isAdmin)
                return Results.Forbid();

            return Results.Ok("Només admins (manual)");
        });
    }
}

// 📌 IMPORTANTE: Va fuera de la clase pero dentro del namespace
public record TokenRequest(string Token);
