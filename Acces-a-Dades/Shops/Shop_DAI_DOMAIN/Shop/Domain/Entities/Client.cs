namespace dbdemo.Domain.Entities;

public class Client
{
/*
ATENCIÓ
     En el domain no ha de constar Id ja que és una decisió de base de dades.
     Utilitzem Guid per què el nostre SGBD disposa d'aquest tipus de dades.
     L'entitat de domini de Product no ha de tenir aquest camp.
     El camp Id pertany exclusivament a l'entitat d'infraestructura (COM guardem el producte a la base de dades).
*/

    public String Codi { get; set; } 
    public String Nom { get; set; }

}