namespace dbdemo.Infraestructure.Persistence.Entitites;

public class ProducteCompraEntity 
{
    public required Guid Id { get; set; }
    public required Guid ID_CARR { get; set; }
    public required Guid ID_PROD { get; set; }
    public required int Quantitat { get; set; }
    public required decimal DataCompra { get; set; }

}
