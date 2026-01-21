using dbdemo.Model;
//Demanar Informacio a la BDD
namespace dbdemo.DTO;

public record ProducteResponse(Guid Id, string Code, string Descripcio, decimal Price, decimal Descompte, Guid IdFamilia, string Name) 
{
    // Guanyem CONTROL sobre com es fa la conversió

    public static ProducteResponse FromProducte(Product producte)   // Conversió de model a response
    {
        return new ProducteResponse(producte.Id, producte.Code, producte.Descripcio, producte.Price, producte.Descompte, producte.IdFamilia, producte.Name);
    }
}
