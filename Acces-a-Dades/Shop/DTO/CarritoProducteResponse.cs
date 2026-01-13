using dbdemo.Model;
//Demanar Informacio a la BDD
namespace dbdemo.DTO;

public record CarritoProducteResponse(Guid Id, string ID_CARR, string ID_PROD, string Quantitat) 
{
    // Guanyem CONTROL sobre com es fa la conversió

    public static CarritoProducteResponse FromCarritoProducte(CarritoProducte carritoProducte)   // Conversió de model a response
    {
        return new CarritoProducteResponse(carritoProducte.Id, carritoProducte.ID_CARR, carritoProducte.ID_PROD, carritoProducte.Quantitat);
    }
}
