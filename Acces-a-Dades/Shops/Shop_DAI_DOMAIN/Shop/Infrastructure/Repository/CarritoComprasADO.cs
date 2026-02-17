using Microsoft.Data.SqlClient;
using static System.Console;
using dbdemo.Services;
using dbdemo.Model;
using dbdemo.Infraestructure.Persistence.Entitites;


namespace dbdemo.Repository;

class CarritoComprasADO
{



    public static PreuProducte? GetPriceById(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();
        string sql = "SELECT Price FROM RegistrePreus WHERE Id_Prod = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        using SqlDataReader reader = cmd.ExecuteReader();
        PreuProducte? preuProducte = null;

        if (reader.Read())
        {
            preuProducte = new PreuProducte
            {
                Price = reader.GetDecimal(0),

            };
        }

        return preuProducte;
    }


    public static void InsertCompraEntity(DatabaseConnection dbConn, CompraEntity compraEntity)
    {

        dbConn.Open();

        string sql = @"INSERT INTO CarritoCompras (Id, Nom, Descripcio, ID_CLI, DataCompra)     
                            VALUES (@Id, @Nom, @Descripcio, @ID_CLI, @DataCompra )";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", compraEntity.Id);
        cmd.Parameters.AddWithValue("@Nom", compraEntity.Nom);
        cmd.Parameters.AddWithValue("@Descripcio", compraEntity.Descripcio);
        cmd.Parameters.AddWithValue("@ID_CLI", compraEntity.ID_CLI);
        cmd.Parameters.AddWithValue("@DataCompra", compraEntity.DataCompra);


        cmd.ExecuteNonQuery();

        dbConn.Close();
    }

    public static void InsertProducteCompraEntity(DatabaseConnection dbConn, ProducteCompraEntity producteCompraEntity)
    {

        dbConn.Open();

        string sql = @"INSERT INTO CarritoProducte (Id, ID_CARR, ID_PROD, Quantitat, Price)     
                            VALUES (@Id, @ID_CARR, @ID_PROD, @Quantitat, @Price )";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", producteCompraEntity.Id);
        cmd.Parameters.AddWithValue("@ID_CARR", producteCompraEntity.ID_CARR);
        cmd.Parameters.AddWithValue("@ID_PROD", producteCompraEntity.ID_PROD);
        cmd.Parameters.AddWithValue("@Quantitat", producteCompraEntity.Quantitat);
        cmd.Parameters.AddWithValue("@Price", producteCompraEntity.Price);


        cmd.ExecuteNonQuery();

        dbConn.Close();
    }






    public static void Insert(DatabaseConnection dbConn, CarritoCompras carritoCompras)
    {

        dbConn.Open();

        string sql = @"INSERT INTO CarritoCompras (Id, Nom, Descripcio)     
                        VALUES (@Id, @Nom, @Descripcio)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", carritoCompras.Id);
        cmd.Parameters.AddWithValue("@Nom", carritoCompras.Nom);
        cmd.Parameters.AddWithValue("@Descripcio", carritoCompras.Descripcio);

        cmd.ExecuteNonQuery();

        dbConn.Close();
    }

    public static List<CarritoCompras> GetAll(DatabaseConnection dbConn)
    {
        List<CarritoCompras> carritoCompras = new();

        dbConn.Open();
        string sql = "SELECT Id, Nom, Descripcio FROM CarritoCompras";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            carritoCompras.Add(new CarritoCompras
            {
                Id = reader.GetGuid(0),
                Nom = reader.GetString(1),
                Descripcio = reader.GetString(2),
            });
        }

        dbConn.Close();
        return carritoCompras;
    }

    public static CarritoCompras? GetById(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();
        string sql = "SELECT Id, Nom, Descripcio FROM CarritoCompras WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        using SqlDataReader reader = cmd.ExecuteReader();
        CarritoCompras? carritoCompras = null;

        if (reader.Read())
        {
            carritoCompras = new CarritoCompras
            {
                Id = reader.GetGuid(0),
                Nom = reader.GetString(1),
                Descripcio = reader.GetString(2),
            };
        }

        dbConn.Close();
        return carritoCompras;
    }

    public static void Update(DatabaseConnection dbConn, CarritoCompras carritoCompras)
    {
        dbConn.Open();

        string sql = @"UPDATE CarritoCompras 
                        SET
                        Id = @Id,
                        Nom = @Nom,
                        Descripcio = @Descripcio
                        WHERE Id = @Id";



        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", carritoCompras.Id);
        cmd.Parameters.AddWithValue("@Nom", carritoCompras.Nom);
        cmd.Parameters.AddWithValue("@Descripcio", carritoCompras.Descripcio);

        dbConn.Close();
    }

    public static bool Delete(DatabaseConnection dbConn, Guid Id)
    {
        dbConn.Open();

        string sql = @"DELETE FROM CarritoCompras WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", Id);

        int rows = cmd.ExecuteNonQuery();

        dbConn.Close();

        return rows > 0;
    }


    public static List<ImportAndCo> GetImportById(DatabaseConnection dbConn, Guid id)
    {
        List<ImportAndCo> importAndCos = new();

        dbConn.Open();
        string sql = "SELECT cp.ID_PROD , cp.Quantitat , p.Price , p.Descompte FROM CarritoProducte cp INNER JOIN Product p ON p.ID = cp.ID_PROD WHERE cp.ID_CARR = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            importAndCos.Add(new ImportAndCo
            {
                ID_PROD = reader.GetGuid(0),
                Quantitat = reader.GetInt32(1),
                Price = reader.GetDecimal(2),
                Descompte = reader.GetDecimal(3)
            });
        }

        dbConn.Close();
        return importAndCos;
    }











}
