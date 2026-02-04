// using dbdemo.Domain.Entities;
// using dbdemo.Common;


// namespace dbdemo.Domain.Validators;

// public static class CarritoProducteLineaValidator
// {
//     public static Result Validate(CarritoProducteLinea carritoProducteLinea)
//     {
//         if (carritoProducteLinea.Price <= 0)
//         {
//             return Result.Failure("El preu ha de ser superior a 0","PREU_INCORRECTE");
//         }
//         if (carritoProducteLinea.Quantitat <= 0)
//         {
//             return Result.Failure("La quantitat ha de ser superior a 0","QUANTITAT_INCORRECTE");
//         }
//         if (carritoProducteLinea.ID_CARR == Guid.Empty )
//         {
//             return Result.Failure("No s'ha asignat cap carrito a la compra","EMPTY_CARRITO");
//         }
//         if (carritoProducteLinea.ID_PROD == Guid.Empty )
//         {
//             return Result.Failure("No s'ha asignat cap producte a la carro","EMPTY_LINES");
//         }
        


//         return Result.Ok();

        
//     }

// }
