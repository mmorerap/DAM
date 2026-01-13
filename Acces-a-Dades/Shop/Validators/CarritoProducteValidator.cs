

using dbdemo.DTO;
using dbdemo.Common;

namespace dbdemo.Validators;

public static class CarritoProducteValidator
{
    public static Result Validate(CarritoProducteRequest carritoProducte)
    {
        if (carritoProducte.ID_CARR == null)
        {
            return Result.Failure("No ha posat cap valor a ID_CARR", "ID_CARR");
        }

        if (carritoProducte.ID_PROD == null)
        {
            return Result.Failure("No ha posat cap valor a ID_PROD", "ID_PROD");
        }
        

        if (carritoProducte.Quantitat <= 0)
        {
            return Result.Failure("No ha posat cap valor a Quantitat", "QUANTITAT");
        }

        return Result.Ok();
        
    }
    
    

}