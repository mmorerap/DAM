

using dbdemo.DTO;
using dbdemo.Common;

namespace dbdemo.Validators;

public static class ProducteValidator
{
    public static Result Validate(ProducteRequest producte)
    {
        if (producte.Name == "")
        {
            return Result.Failure("No ha posat cap Nom a la familia", "NOM_EMPTY");
        }

        if (producte.Name.Length > 30 )
        {
            return Result.Failure("Longitud màxima excedida","MAX_LENGTH_EXCEEDED");
        }
        return Result.Ok();
    }
    
    

}