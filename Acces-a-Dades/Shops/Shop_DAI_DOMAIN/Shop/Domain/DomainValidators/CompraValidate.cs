using dbdemo.Domain.Entities;
using dbdemo.Common;

namespace dbdemo.Validators;

public static class CompraValidator
{
    public static Result Validate(Compra compra)
    {
        if (compra == null)
            return Result.Failure("La compra no pot ser null", "COMPRA_NULL");

        if (compra.client == null)
            return Result.Failure("El client no pot ser null", "CLIENT_NULL");

        
        if (compra.Data == default)
            return Result.Failure("La data és obligatòria", "DATA_BUITA");


        if (compra.Lineas == null)
            return Result.Failure("Les línies no poden ser null", "LINEAS_NULL");

        foreach (var linea in compra.Lineas)
        {
            if (linea == null)
                return Result.Failure("La línia no pot ser null", "LINEA_NULL");

            if (linea.quantitat <= 0)
                return Result.Failure("La quantitat ha de ser major que 0", "QUANTITAT_INVALIDA");
        }

        return Result.Ok();
    }
}
