using dbdemo.Domain.Entities;
using dbdemo.Endpoints;
using dbdemo.Model;

namespace dbdemo.DTO;

public record CompraRequest( Guid IdClient, DateOnly Data, List<ProducteCompraRequest>Productes /* List<ProducteCompraRequest>Productes*/) 
{
    // Guanyem CONTROL sobre com es fa la conversió

    public Compra ToCompra()   // Conversió a domain
    {
        
        Client client = new Client();
        client.Codi = IdClient.ToString();


        Compra compraDomain = new Compra();
        compraDomain.client = client;

        

        return compraDomain;

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



        // return new Compra
        // {
        //     client = {Codi,Nom},
        //     Lineas = IdClient,
        //     Descripcio = Descripcio
        // };