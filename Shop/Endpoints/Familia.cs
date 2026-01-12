using dbdemo.Repository;
using dbdemo.Services;
using dbdemo.Model;
using dbdemo.DTO;
using dbdemo.Common;
using dbdemo.Validators;
// using dbdemo.Validators;
// using dbdemo.Common;


namespace dbdemo.Endpoints;

public static class EndpointsFamilia
{
    public static void MapFamiliaEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /families
        app.MapGet("/familias", () =>
        {
            List<Familia> familias = FamiliaADO.GetAll(dbConn);
            List<FamiliaResponse> familiaResponses = new List<FamiliaResponse>();
            foreach (Familia familia in familias)
            {
                familiaResponses.Add(FamiliaResponse.FromFamilia(familia));
            }
            return Results.Ok(familiaResponses);
        });

        // GET Familia by id
        app.MapGet("/familia/{id}", (Guid id) =>
        {
            Familia familia = FamiliaADO.GetById(dbConn, id)!;

            return familia is not null
                ? Results.Ok(FamiliaResponse.FromFamilia(familia))
                : Results.NotFound(new { message = $"Familia with Id {id} not found." });


        });




        // POST /familia
        app.MapPost("/familia", (FamiliaRequest req) =>
        {
            Result result = FamiliaValidator.Validate(req);
            Familia familia = new Familia
            {
                Id = Guid.NewGuid(),
                Nom = req.Nom,
                Descripcio = req.Descripcio
            };

            FamiliaADO.Insert(dbConn, familia);

            return Results.Created($"/products/{familia.Id}", familia);
        });
    }


}

// public record FamiliaRequest(string Nom, string Descripcio);  // Com ha de llegir el POST

