using dbdemo.Model;
//Demanar Informacio a la BDD
namespace dbdemo.DTO;

public record CarritoCompraResponse(Guid Id, string Nom, string Descripcio) 
{
    // Guanyem CONTROL sobre com es fa la conversió

    public static CarritoCompraResponse FromCarritoCompras(CarritoCompras carritoCompras)   // Conversió de model a response
    {
        return new CarritoCompraResponse(carritoCompras.Id, carritoCompras.Nom, carritoCompras.Descripcio);
    }
}
