

using dbdemo.Infraestructure.Persistence.Entitites;
using dbdemo.Domain.Entities;

namespace dbdemo.Infraestructure.Mappers;

public static class CompraMapper
{
  
    public static CompraEntity ToEntity(Guid IdCompra, String descripcio , Compra compra )
        => new CompraEntity
        {
            Id = IdCompra,
            Nom = compra.client.Codi,
            Descripcio = descripcio,
            ID_CLI = Guid.Parse(compra.client.Codi),
            DataCompra = compra.Data
        };
}

