using dbdemo.Repository;
using dbdemo.Services;
using dbdemo.Model;
using dbdemo.DTO;
using dbdemo.Common;
using dbdemo.Validators;

namespace dbdemo.Endpoints;

public static class EndpointsProduct
{
    public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /products
        app.MapGet("/products", () =>
        {
            List<Product> products = ProductADO.GetAll(dbConn);
            List<ProducteResponse> producteResponses = new List<ProducteResponse>();
            foreach (Product product in products)
            {
                producteResponses.Add(ProducteResponse.FromProducte(product));
            }
            return Results.Ok(producteResponses);
        });

        // GET Product by id
        app.MapGet("/products/{id}", (Guid id) =>
        {
            Product? product = ProductADO.GetById(dbConn, id);

            return product is not null
                ? Results.Ok(ProducteResponse.FromProducte(product))
                : Results.NotFound(new { message = $"Product with Id {id} not found." });


        });




        // POST /product
        app.MapPost("/product", (ProducteRequest req) =>
        {
            Guid id;
            Result result = ProducteValidator.Validate(req);

            if (!result.IsOk)
            {
                return Results.BadRequest(new 
                {
                    error = result.ErrorCode,
                    message = result.ErrorMessage
                });
            }


            id =  Guid.NewGuid();
            Product product = req.ToProducte(id);
            ProductADO.Insert(dbConn, product);

            return Results.Created($"/products/{product.Id}", product);
        });

        // UPDATE /product/{id}
        app.MapPut("/product/{id}", (Guid id, ProducteRequest req) =>
        {
            Result result = ProducteValidator.Validate(req);

            if (!result.IsOk)
            {
                return Results.BadRequest(new
                {
                    error = result.ErrorCode,
                    message = result.ErrorMessage
                });
            }

            Product? product = ProductADO.GetById(dbConn, id);

            if (product == null)
            {
                return Results.NotFound();
            }

            Product producteUpdt = req.ToProducte(id);

            ProductADO.Update(dbConn, producteUpdt);
            return Results.Ok(producteUpdt);
        });

        // DELETE /product/{id}
        app.MapDelete("/product/{id}", (Guid id) => ProductADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());

        
    }


}

//public record ProductRequest(string Code, string Descripcio, decimal Price ,decimal Descompte,Guid IdFamilia,string Name); 

