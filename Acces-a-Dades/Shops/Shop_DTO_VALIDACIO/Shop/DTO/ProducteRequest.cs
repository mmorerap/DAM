

/*
DTO (Data Transfer Object): És una representació simplificada de les dades que es volen transferir 
entre les capes. Sovint és una estructura més lleugera que una entitat del model de dades, amb només 
les propietats necessàries per ser transportades entre les capes. 

Per exemple, el ProductRequest és un DTO perquè encapsula només les propietats necessàries per crear o 
actualitzar un producte a través de la API, sense necessitar totes les propietats que podrien formar part 
del model de dades intern.
*/
using dbdemo.Model;

namespace dbdemo.DTO;

public record ProducteRequest( string Code, string Descripcio, decimal Price, decimal Descompte, Guid IdFamilia, string Name) 
{
    // Guanyem CONTROL sobre com es fa la conversió

    public Product ToProducte(Guid id)   // Conversió a model
    {

        return new Product
        {
            Id = id,
            Code = Code,
            Descripcio = Descripcio,
            Price = Price,
            Descompte = Descompte,
            IdFamilia = IdFamilia,
            Name = Name
        };
    }
}
