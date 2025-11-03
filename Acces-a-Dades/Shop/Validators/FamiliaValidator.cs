

using dbdemo.DTO;
using dbdemo.Common;

namespace dbdemo.Validators;

public static class FamiliaValidator
{
    public static Result Validate(FamiliaRequest familia)
    {
        if (familia.Nom != "")
        {
            return Result.Failure("No ha posat cap Nom a la familia", "NOM_EMPTY");
        }

        if (familia.Nom.Length > 20 )
        {
            return Result.Failure("No ha posat cap Nom a la familia","NOM_EMPTY");
        }
        return Result.Ok();
    }
    
    

}