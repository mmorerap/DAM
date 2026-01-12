using Microsoft.Data.SqlClient;
using static System.Console;
using dbdemo.Services;
using dbdemo.Model;


namespace dbdemo.Repository;

class CarritoComprasADO
{
   

    public static void Insert(DatabaseConnection dbConn, CarritoCompras carritoCompras)
    {

        dbConn.Open();

        string sql = @"INSERT INTO CarritoCompras (Id, Nom, Descripcio)     
                        VALUES (@Id, @Nom, @Descripcio)";            

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", carritoCompras.Id);
        cmd.Parameters.AddWithValue("@Nom", carritoCompras.Nom);
        cmd.Parameters.AddWithValue("@Descripcio", carritoCompras.Descripcio);
        
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
        string sql = "SELECT Id, Nom FROM CarritoCompras WHERE Id = @Id";

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
}
