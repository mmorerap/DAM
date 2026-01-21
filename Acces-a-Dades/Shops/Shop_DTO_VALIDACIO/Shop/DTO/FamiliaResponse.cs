using dbdemo.Model;
//Demanar Informacio a la BDD
namespace dbdemo.DTO;

public record FamiliaResponse(Guid Id, string Nom, string Descripcio) 
{
    // Guanyem CONTROL sobre com es fa la conversió

    public static FamiliaResponse FromFamilia(Familia familia)   // Conversió de model a response
    {
        return new FamiliaResponse(familia.Id,  familia.Nom, familia.Descripcio);
    }
}
