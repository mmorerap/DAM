using dbdemo.Repository;
using dbdemo.Services;
using dbdemo.Model;
using dbdemo.DTO;
namespace dbdemo.Endpoints;

public static class EndpointsCarritoCompras
{
    public static void MapCarritoComprasEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /products
        app.MapGet("/CarritoCompras", () =>
        {
            List<CarritoCompras> CarritoCompras = CarritoComprasADO.GetAll(dbConn);
            return Results.Ok(CarritoCompras);
        });

        // GET CarritoCompra by id
        app.MapGet("/CarritoCompra/{id}", (Guid id) =>
        {
            CarritoCompras carritoCompra = CarritoComprasADO.GetById(dbConn, id)!;

            return carritoCompra is not null
                ? Results.Ok(carritoCompra)
                : Results.NotFound(new { message = $"CarritoCompras with Id {id} not found." });


        });




        // POST /familia
        app.MapPost("/CarritoCompra", (FamiliaRequest req) =>
        {
            CarritoCompras carritoCompra = new CarritoCompras
            {
                Id = Guid.NewGuid(),
                Nom = req.Nom,
            };

            CarritoComprasADO.Insert(dbConn, carritoCompra);

            return Results.Created($"/CarritoCompra/{carritoCompra.Id}", carritoCompra);
        });


        //UPTATE

        //IMPORT aplicar descomptes utilitzan querry string FACTORY




    }


}

public record CarritoCompra(string Nom);  // Com ha de llegir el POST

