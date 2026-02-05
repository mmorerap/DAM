using dbdemo.Repository;
using dbdemo.Services;
using dbdemo.Model;
using dbdemo.DTO;
using dbdemo.Validators;
using dbdemo.Common;
using dbdemo.Factory;
using dbdemo.Domain.Entities;
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



      
        app.MapGet("/carritoCompra/{id}/import", (Guid id, string TipoDescompte = "Normal") =>
        {
            List<ImportAndCo> importAndCo = CarritoComprasADO.GetImportById(dbConn, id);

            if (importAndCo is null || importAndCo.Count == 0)
            {
                return Results.NotFound(new
                {
                    message = $"CarritoCompras with Id {id} not found."
                });
            }

            IDescompteFactory factory = TipoDescompte switch
            {
                "Normal" => new DescompteNormalFactory(),
                "Premium" => new DescomptePrmiumFactory(),
                _ => throw new ArgumentException("Tipus de descompte desconegut.")
            };

            IDescompteTipe descompte = factory.CreateDescompte();
            Decimal import = CalculsCarro.Calcular(importAndCo);
            Decimal dte = descompte.CalcularDescompte(import);
            

            return Results.Ok(new {dte,import,importAndCo});
        });












        // POST /carritoCompra SENSE BASE
        /*
            {
                "Client": "BCDF590A-E279-485A-928C-31D0AFEF0598BCDF590A-E279-485A-928C-31D0AFEF0598",
                "Data": "2026-10-12",
                "Productes": [
                    {"Producte":"BCDF590A-E279-485A-928C-31D0AFEF0511","Quantitat":2},
                    {"Producte":"8C7E2A40-3390-426A-89BF-62ECF9A5A537","Quantitat":4}
                ]
            }
        */
        app.MapPost("/compra", (CompraRequest req) =>
        {

            Compra compra = req.ToCompra();
            // Result result = CompraValidator.Validate(compra);
            //  if (!result.IsOk)
            // {
            //     return Results.BadRequest(new 
            //     {
            //         error = result.ErrorCode,
            //         message = result.ErrorMessage
            //     });
            // }

            // CarritoComprasADO.Insert(dbConn, compra);

            return Results.Ok(compra);
        });
























        
        // // UPDATE /carritoCompra/{id}
        // app.MapPut("/carritoCompra/{id}", (Guid id, CarritoCompraRequest req) =>
        // {
        //     Result result = CarritoComprasValidator.Validate(req);
        //     if (!result.IsOk)
        //     {
        //         return Results.BadRequest(new 
        //         {
        //             error = result.ErrorCode,
        //             message = result.ErrorMessage
        //         });
        //     }

        //     CarritoCompras? carritoCompras = CarritoComprasADO.GetById(dbConn, id);

        //     if (carritoCompras == null)
        //     {
        //         return Results.NotFound();
        //     }

        //     CarritoCompras carritoComprasUpdt = req.ToCarritoCompra(id);

        //     CarritoComprasADO.Update(dbConn, carritoComprasUpdt);
        //     return Results.Ok(CarritoCompraResponse.FromCarritoCompras(carritoComprasUpdt));
        // });

        // DELETE /carritoCompra/{id}
        app.MapDelete("/carritoCompra/{id}", (Guid id) => CarritoComprasADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());



    }


}

public record CarritoCompra(string Nom);  // Com ha de llegir el POST

