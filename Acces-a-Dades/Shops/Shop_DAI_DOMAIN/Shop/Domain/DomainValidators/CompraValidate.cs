using dbdemo.Domain.Entities;
using dbdemo.Common;

namespace dbdemo.Validators;

public static class CompraValidator
{
    public static Result Validate(Compra compra)
    {
        if (compra == null)
            return Result.Failure("La compra no pot ser null", "COMPRA_NULL");

        // CLIENT
        if (compra.client == null)
            return Result.Failure("El client no pot ser null", "CLIENT_NULL");

        if (string.IsNullOrWhiteSpace(compra.client.Codi))
            return Result.Failure("El codi del client és obligatori", "CLIENT_CODI_BUIT");

        // DATA
        if (compra.Data == default)
            return Result.Failure("La data és obligatòria", "DATA_BUITA");

        // LINEAS
        if (compra.Lineas == null)
            return Result.Failure("Les línies no poden ser null", "LINEAS_NULL");

        if (!compra.Lineas.Any())
            return Result.Failure("La compra ha de tenir línies", "LINEAS_BUIDES");

        // VALIDACIÓ DE CADA LÍNIA
        foreach (var linea in compra.Lineas)
        {
            if (linea == null)
                return Result.Failure("La línia no pot ser null", "LINEA_NULL");

            if (linea.producte == null)
                return Result.Failure("El producte no pot ser null", "PRODUCTE_NULL");

            if (string.IsNullOrWhiteSpace(linea.producte.Codi))
                return Result.Failure("El codi del producte és obligatori", "PRODUCTE_CODI_BUIT");

            if (linea.quantitat <= 0)
                return Result.Failure("La quantitat ha de ser major que 0", "QUANTITAT_INVALIDA");
        }

        return Result.Ok();
    }
}
