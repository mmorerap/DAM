using dbdemo.Model;

namespace dbdemo.DTO;

public record CarritoProducteRequest( Guid ID_CARR, Guid ID_PROD, int Quantitat) 
{
    // Guanyem CONTROL sobre com es fa la conversió

    public CarritoProducte ToCarritoProducte(Guid id)   // Conversió a model
    {

        return new CarritoProducte
        {
            Id = id,
            ID_CARR = ID_CARR,
            ID_PROD = ID_PROD,
            Quantitat = Quantitat
        };
    }
}
