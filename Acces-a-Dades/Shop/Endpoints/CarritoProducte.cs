using dbdemo.Repository;
using dbdemo.Services;
using dbdemo.Model;
using dbdemo.DTO;
using dbdemo.Common;
using dbdemo.Validators;
// using dbdemo.Validators;
// using dbdemo.Common;


namespace dbdemo.Endpoints;

public static class EndpointsCarritoProducte
{
    public static void MapCarritoProducteEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /carritoProductes
        app.MapGet("/carritoProductes", () =>
        {
            List<CarritoProducte> carritoProductes = CarritoProducteADO.GetAll(dbConn);
            List<CarritoProducteResponse> carritoProducteResponses = new List<CarritoProducteResponse>();
            foreach (CarritoProducte carritoProducte in carritoProductes)
            {
                carritoProducteResponses.Add(CarritoProducteResponse.FromCarritoProducte(carritoProducte));
            }
            return Results.Ok(carritoProducteResponses);
        });

        // GET carritoProducte by id
        app.MapGet("/carritoProducte/{id}", (Guid id) =>
        {
            CarritoProducte carritoProducte = CarritoProducteADO.GetById(dbConn, id)!;

            return carritoProducte is not null
                ? Results.Ok(CarritoProducteResponse.FromCarritoProducte(carritoProducte))
                : Results.NotFound(new { message = $"CarritoProducte with Id {id} not found." });
            
        });




        // POST /carritoProducte
        app.MapPost("/carritoProducte", (CarritoProducteRequest req) =>
        {
            Result result = CarritoProducteValidator.Validate(req);

            //posarho a families
            if (!result.IsOk)
            {
                return Results.BadRequest(new 
                {
                    error = result.ErrorCode,
                    message = result.ErrorMessage
                });
            }

            CarritoProducte carritoProducte = new CarritoProducte
            {
                Id = Guid.NewGuid(),
                ID_CARR = req.ID_CARR,
                ID_PROD = req.ID_PROD,
                Quantitat = req.Quantitat
            };

            CarritoProducteADO.Insert(dbConn, carritoProducte);

            return Results.Created($"/carritoProducte/{carritoProducte.Id}", carritoProducte);
        });


        // UPDATE /carritoProducte/{id}
        app.MapPut("/carritoProducte/{id}", (Guid id, CarritoProducteRequest req) =>
        {
            var existing = CarritoProducteADO.GetById(dbConn, id);

            if (existing == null)
            {
                return Results.NotFound();
            }

            CarritoProducte updated = new CarritoProducte
            {
                Id = id,
                ID_CARR = req.ID_CARR,
                ID_PROD = req.ID_PROD,
                Quantitat = req.Quantitat
            };

            CarritoProducteADO.Update(dbConn, updated);
            return Results.Ok(updated);
        });

        // DELETE /carritoProducte/{id}
        app.MapDelete("/carritoProducte/{id}", (Guid id) => CarritoProducteADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());

    }


}

// public record FamiliaRequest(string Nom, string Descripcio);  // Com ha de llegir el POST

