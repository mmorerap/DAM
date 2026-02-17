

using dbdemo.Infraestructure.Persistence.Entitites;
using dbdemo.Domain.Entities;

namespace dbdemo.Infraestructure.Mappers;

public static class ProducteCompraMapper
{
  
    public static ProducteCompraEntity ToEntity(Guid id_LineaProducte ,Guid Id_Carr,Guid idProducte , decimal preuProducte , decimal quantitat )
        => new ProducteCompraEntity
        {
            Id = id_LineaProducte,
            ID_CARR = Id_Carr,
            ID_PROD = idProducte,
            Quantitat = quantitat,
            Price = preuProducte
           
        };
}

