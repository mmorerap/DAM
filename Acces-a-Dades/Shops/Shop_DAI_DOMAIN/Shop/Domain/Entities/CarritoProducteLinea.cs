namespace dbdemo.Domain.Entities;

public class CarritoProducteLinea
{

    public Guid ID_CARR { get; set; }
    public Producte producte { get; set; }
    public decimal Price { get; set; }


    // public CarritoProducteLinea(Guid Id_carr, decimal price, Producte producte)
    // {
    //     ID_CARR=Id_carr;
    //     producte = producte;
    //     Price=price;

    // }

}