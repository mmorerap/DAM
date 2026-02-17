namespace dbdemo.Infraestructure.Persistence.Entitites;

public class ProducteCompraEntity
{
    public required Guid Id { get; set; }
    public required Guid ID_CARR { get; set; }
    public required Guid ID_PROD { get; set; }
    public required decimal Quantitat { get; set; }
    public required decimal Price { get; set; }

}
