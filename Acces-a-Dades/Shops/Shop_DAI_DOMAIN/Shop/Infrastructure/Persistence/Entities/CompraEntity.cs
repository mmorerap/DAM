namespace dbdemo.Infraestructure.Persistence.Entitites;

public class CompraEntity 
{
    public required Guid Id { get; set; }
    public required string Nom { get; set; }
    public required string Descripcio { get; set; }
    public required Guid ID_CLI { get; set; }
    public required DateTime DataCompra { get; set; }

}

