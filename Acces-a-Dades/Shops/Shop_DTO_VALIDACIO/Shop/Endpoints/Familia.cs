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
        // GET /familias
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
            Guid id;
            Result result = FamiliaValidator.Validate(req);

            if (!result.IsOk)
            {
                return Results.BadRequest(new 
                {
                    error = result.ErrorCode,
                    message = result.ErrorMessage
                });
            }

            id = Guid.NewGuid();
            Familia familia = req.ToFamilia(id);
            FamiliaADO.Insert(dbConn, familia);

            return Results.Created($"/familia/{familia.Id}", FamiliaResponse.FromFamilia(familia));
        });


        // UPDATE /familia/{id}
        app.MapPut("/familia/{id}", (Guid id, FamiliaRequest req) =>
        {
            Result result = FamiliaValidator.Validate(req);
            if (!result.IsOk)
            {
                return Results.BadRequest(new 
                {
                    error = result.ErrorCode,
                    message = result.ErrorMessage
                });
            }

            Familia? familia = FamiliaADO.GetById(dbConn, id);

            if (familia == null)
            {
                return Results.NotFound();
            }

            Familia familiaUpdt = req.ToFamilia(id);

            FamiliaADO.Update(dbConn, familiaUpdt);
            return Results.Ok(FamiliaResponse.FromFamilia(familiaUpdt));
        });

        // DELETE /familia/{id}
        app.MapDelete("/familia/{id}", (Guid id) => FamiliaADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());

    }


}

// public record FamiliaRequest(string Nom, string Descripcio);  // Com ha de llegir el POST

