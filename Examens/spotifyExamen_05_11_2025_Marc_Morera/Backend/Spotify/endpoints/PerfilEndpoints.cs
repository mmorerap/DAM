using Spotify.Repository;
using Spotify.Services;
using Spotify.Model;

namespace Spotify.Endpoints;

public static class PerfilEndpoints
{
    public static void MapPerfilEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        

        // POST /perfil
        app.MapPost("/perfil", (PerfilRequest req) =>
        {
            Perfil perfil = new Perfil
            {
                Id = Guid.NewGuid(),
                Name = req.Name,
                Descripcio = req.Descripcio,
                Estat = req.Estat,
                User_Id = req.User_ID

            };

            PerfilADO.Insert(dbConn, perfil);

            return Results.Created($"/perfil/{perfil.Id}", perfil);
        });



    }
}

// DTO pel request
public record PerfilRequest(Guid Id, string Name, string Descripcio, string Estat, Guid User_ID);
