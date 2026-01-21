namespace dbdemo.Model;

public class CarritoProducte
{
    public Guid Id { get; set; }
    public Guid ID_CARR { get; set; }
    public Guid ID_PROD { get; set; }
    public int Quantitat { get; set; } = 1;
}