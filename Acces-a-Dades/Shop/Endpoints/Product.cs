using dbdemo.Repository;
using dbdemo.Services;
using dbdemo.Model;

namespace dbdemo.Endpoints;

public static class EndpointsProduct
{
    public static void MapProductEndpoints(this WebApplication app, DatabaseConnection dbConn)
    {
        // GET /products
        app.MapGet("/products", () =>
        {
            List<Product> products = ProductADO.GetAll(dbConn);
            return Results.Ok(products);
        });

        // GET Product by id
        app.MapGet("/products/{id}", (Guid id) =>
        {
            Product? product = ProductADO.GetById(dbConn, id);

            return product is not null
                ? Results.Ok(product)
                : Results.NotFound(new { message = $"Product with Id {id} not found." });


        });




        // POST /product
        app.MapPost("/product", (ProductRequest req) =>
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                Code = req.Code,
                Descripcio = req.Descripcio,
                Price = req.Price,
                Descompte = req.Descompte,
                IdFamilia = req.IdFamilia,
                Name = req.Name,
            };

            ProductADO.Insert(dbConn, product);

            return Results.Created($"/products/{product.Id}", product);
        });

        // UPDATE /product/{id}
        app.MapPut("/product/{id}", (Guid id, ProductRequest req) =>
        {
            var existing = ProductADO.GetById(dbConn, id);

            if (existing == null)
            {
                return Results.NotFound();
            }

            Product updated = new Product
            {
                Id = id,
                Code = req.Code,
                Descripcio = req.Descripcio,
                Price = req.Price,
                Descompte = req.Descompte,
                IdFamilia = req.IdFamilia,
                Name = req.Name
            };

            ProductADO.Update(dbConn, updated);

            return Results.Ok(updated);
        });

        // DELETE /product/{id}
        app.MapDelete("/product/{id}", (Guid id) => ProductADO.Delete(dbConn, id) ? Results.NoContent() : Results.NotFound());

        
    }


}

public record ProductRequest(string Code, string Descripcio, decimal Price ,decimal Descompte,Guid IdFamilia,string Name); 

