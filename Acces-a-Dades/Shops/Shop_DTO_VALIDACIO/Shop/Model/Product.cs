namespace dbdemo.Model;

public class Product
{
    public Guid Id { get; set; }
    public string Code { get; set; } = "";
    public string Descripcio { get; set; } = "";
    public decimal Price { get; set; }
    public decimal Descompte { get; set; }
    public Guid IdFamilia { get; set; } 
    public string Name { get; set; } = "";
}