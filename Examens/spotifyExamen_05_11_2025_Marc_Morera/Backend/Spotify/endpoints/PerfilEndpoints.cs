using Spotify.Repository;
using Spotify.Services;
using Spotify.Model;

namespace Spotify.Endpoints;

public static class PerfilEndpoints
{
    public static void MapPerfilEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /perfils
        app.MapGet("/perfils", () =>
        {
            List<Perfil> perfils = PerfilADO.GetAll(dbConn);
            return Results.Ok(perfils);
        });

        // GET perfil by id
        app.MapGet("/perfil/{Id}", (Guid Id) =>
        {
            Perfil perfil = PerfilADO.GetById(dbConn, Id);

            return perfil is not null
                ? Results.Ok(perfil)
                : Results.NotFound(new { message = $"Perfil with Id {Id} not found." });
        });

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

        app.MapPut("/perfil/{id}", (Guid id, PerfilRequest req) =>
        {
            var existing = PerfilADO.GetById(dbConn, id);

            if (existing == null)
            {
                return Results.NotFound();
            }

            Perfil updated = new Perfil
            {
                Id = id,
                Name = req.Name,
                Descripcio = req.Descripcio,
                Estat = req.Estat,
                User_Id = req.User_ID
            };

            PerfilADO.Update(dbConn, updated);

            return Results.Ok(updated);
        });

        // DELETE /playlists/{id}
        app.MapDelete("/perfil/{id}", (Guid id) => PerfilADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());


    }
}

// DTO pel request
public record PerfilRequest(Guid Id, string Name, string Descripcio, string Estat, Guid User_ID);
