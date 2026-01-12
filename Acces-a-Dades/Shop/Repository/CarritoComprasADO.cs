using Microsoft.Data.SqlClient;
using static System.Console;
using dbdemo.Services;
using dbdemo.Model;


namespace dbdemo.Repository;

class CarritoComprasADO
{
   

    public static void Insert(DatabaseConnection dbConn,CarritoCompras carritoCompras)
    {

        dbConn.Open();

        string sql = @"INSERT INTO CarritoCompras (Id, Nom)         
                        VALUES (@Id, @Nom)";            

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", carritoCompras.Id);
        cmd.Parameters.AddWithValue("@Nom", carritoCompras.Nom);

        int rows = cmd.ExecuteNonQuery();
        Console.WriteLine($"{rows} fila inserida.");
        dbConn.Close();
    }

    public static List<CarritoCompras> GetAll(DatabaseConnection dbConn)
    {
        List<CarritoCompras> carritoCompras = new();

        dbConn.Open();
        string sql = "SELECT Id, Nom FROM CarritoCompras";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            carritoCompras.Add(new CarritoCompras
            {
                Id = reader.GetGuid(0),
                Nom = reader.GetString(1),
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
            };
        }

        dbConn.Close();
        return carritoCompras;
    }
}
