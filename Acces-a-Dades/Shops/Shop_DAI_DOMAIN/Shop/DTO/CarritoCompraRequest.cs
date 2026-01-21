using dbdemo.Endpoints;
using dbdemo.Model;

namespace dbdemo.DTO;

public record CarritoCompraRequest( string Nom, string Descripcio) 
{
    // Guanyem CONTROL sobre com es fa la conversió

    public CarritoCompras ToCarritoCompra(Guid id)   // Conversió a model
    {

        return new CarritoCompras
        {
            Id = id,
            Nom = Nom,
            Descripcio = Descripcio
        };
    }
}
