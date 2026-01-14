using dbdemo.Repository;
using dbdemo.Services;
using dbdemo.Model;
using dbdemo.DTO;
using dbdemo.Validators;
using dbdemo.Common;
namespace dbdemo.Endpoints;

public static class EndpointsCarritoCompras
{
    public static void MapCarritoComprasEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /CarritoCompras
        app.MapGet("/carritoCompras", () =>
        {
            List<CarritoCompras> CarritoCompras = CarritoComprasADO.GetAll(dbConn);
            List<CarritoCompraResponse> CarritoComprasResponses = new List<CarritoCompraResponse>();
            foreach (CarritoCompras carritoCompras in CarritoCompras)
            {
                CarritoComprasResponses.Add(CarritoCompraResponse.FromCarritoCompras(carritoCompras));   
            }
            return Results.Ok(CarritoCompras);
        });

        // GET CarritoCompra by id
        app.MapGet("/carritoCompra/{id}", (Guid id) =>
        {
            CarritoCompras carritoCompras = CarritoComprasADO.GetById(dbConn, id)!;

            return carritoCompras is not null
                ? Results.Ok(CarritoCompraResponse.FromCarritoCompras(carritoCompras))
                : Results.NotFound(new { message = $"CarritoCompras with Id {id} not found." });

        });




        // POST /carritoCompra
        app.MapPost("/carritoCompra", (CarritoCompraRequest req) =>
        {
            CarritoCompras carritoCompra = new CarritoCompras
            {
                Id = Guid.NewGuid(),
                Nom = req.Nom,
            };

            CarritoComprasADO.Insert(dbConn, carritoCompra);

            return Results.Created($"/carritoCompra/{carritoCompra.Id}", carritoCompra);
        });







        
        // UPDATE /carritoCompra/{id}
        app.MapPut("/carritoCompra/{id}", (Guid id, CarritoCompraRequest req) =>
        {
            Result result = CarritoComprasValidator.Validate(req);
            if (!result.IsOk)
            {
                return Results.BadRequest(new 
                {
                    error = result.ErrorCode,
                    message = result.ErrorMessage
                });
            }

            CarritoCompras? carritoCompras = CarritoComprasADO.GetById(dbConn, id);

            if (carritoCompras == null)
            {
                return Results.NotFound();
            }

            CarritoCompras carritoComprasUpdt = req.ToCarritoCompra(id);

            CarritoComprasADO.Update(dbConn, carritoComprasUpdt);
            return Results.Ok(CarritoCompraResponse.FromCarritoCompras(carritoComprasUpdt));
        });

        // DELETE /carritoCompra/{id}
        app.MapDelete("/carritoCompra/{id}", (Guid id) => CarritoComprasADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());




    }


}

public record CarritoCompra(string Nom);  // Com ha de llegir el POST

