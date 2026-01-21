

using dbdemo.DTO;
using dbdemo.Common;

namespace dbdemo.Validators;

public static class CarritoComprasValidator
{
    public static Result Validate(CarritoCompraRequest carritoCompra)
    {

        if (carritoCompra.Nom.Length > 10)
        {
            return Result.Failure("Longitud de Nom excedida", "Nom");
        }

        if (carritoCompra.Descripcio.Length > 100)
        {
            return Result.Failure("Longitud de Descripcio excedida", "Descripcio");
        }
        

        if (carritoCompra.Nom == string.Empty)
        {
            return Result.Failure("No ha posat cap valor a Nom", "Nom");
        }

        return Result.Ok();
        
    }
    
    

}