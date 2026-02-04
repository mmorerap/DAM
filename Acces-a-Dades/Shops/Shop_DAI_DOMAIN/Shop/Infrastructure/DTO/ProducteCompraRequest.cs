using dbdemo.Domain.Entities;
using dbdemo.Endpoints;
using dbdemo.Model;

namespace dbdemo.DTO;

public record ProducteCompraRequest( Guid IdProducte, Decimal Quantitat) 
{

    public CarritoProducteLinea ToProducte() 
    {
        Producte producte = new Producte();
        // producteC.Codi = IdProducte.ToString();

        CarritoProducteLinea linea = new CarritoProducteLinea();
        linea.quantitat = Quantitat;
        
        linea.producte = producte;
        
        return linea;
    }
}


 /*
            {
                "Client": "BCDF590A-E279-485A-928C-31D0AFEF0598BCDF590A-E279-485A-928C-31D0AFEF0598",
                "Data": "2026-10-12",
                "Productes": [
                    {"Producte":"BCDF590A-E279-485A-928C-31D0AFEF0511","Quantitat":2},
                    {"Producte":"8C7E2A40-3390-426A-89BF-62ECF9A5A537","Quantitat":4}
                ]
            }
        */