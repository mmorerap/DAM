using Microsoft.Data.SqlClient;
using static System.Console;
using dbdemo.Services;
using dbdemo.Model;


namespace dbdemo.Repository;

class CarritoProducteADO
{
   

    public static void Insert(DatabaseConnection dbConn, CarritoProducte carritoProducte)
    {

        dbConn.Open();

        string sql = @"INSERT INTO CarritoProducte (Id, ID_CARR, ID_PROD, Quantitat)     
                        VALUES (@Id, @ID_CARR, @ID_PROD, @Quantitat)";            

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", carritoProducte.Id);
        cmd.Parameters.AddWithValue("@ID_CARR", carritoProducte.ID_CARR);
        cmd.Parameters.AddWithValue("@ID_PROD", carritoProducte.ID_PROD);
        cmd.Parameters.AddWithValue("@Quantitat", carritoProducte.Quantitat);

        cmd.ExecuteNonQuery();

        dbConn.Close();
    }

    public static List<CarritoProducte> GetAll(DatabaseConnection dbConn)
    {
        List<CarritoProducte> carritoProductes = new();

        dbConn.Open();
        string sql = "SELECT Id, ID_CARR, ID_PROD, Quantitat FROM CarritoProducte";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            carritoProductes.Add(new CarritoProducte
            {
                Id = reader.GetGuid(0),
                ID_CARR = reader.GetString(1),
                ID_PROD = reader.GetString(2),
                Quantitat = reader.GetInt32(3),
            });
        }

        dbConn.Close();
        return carritoProductes;
    }

    public static CarritoProducte? GetById(DatabaseConnection dbConn, Guid id)

    {
        dbConn.Open();
        string sql = "SELECT Id, ID_CARR, ID_PROD, Quantitat FROM CarritoProducte WHERE Id = @Id";
        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        using SqlDataReader reader = cmd.ExecuteReader();
        CarritoProducte? carritoProducte = null;

        if (reader.Read())
        {
            carritoProducte = new CarritoProducte
            {
                Id = reader.GetGuid(0),
                ID_CARR = reader.GetString(1),
                ID_PROD = reader.GetString(2),
                Quantitat = reader.GetInt32(3),
            };
        }

        dbConn.Close();
        return carritoProducte;
    }


     public static void Update(DatabaseConnection dbConn, CarritoProducte carritoProducte)
    {
        dbConn.Open();

        string sql = @"UPDATE CarritoProducte 
                        SET
                        Id = @Id,
                        ID_CARR = @ID_CARR,
                        ID_PROD = @ID_PROD,
                        Quantitat = @Quantitat
                        WHERE Id = @Id";
                       


        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", carritoProducte.Id);
        cmd.Parameters.AddWithValue("@ID_CARR", carritoProducte.ID_CARR);
        cmd.Parameters.AddWithValue("@ID_PROD", carritoProducte.ID_PROD);
        cmd.Parameters.AddWithValue("@Quantitat", carritoProducte.Quantitat);

        dbConn.Close();
    }

    public static bool Delete(DatabaseConnection dbConn, Guid Id)
    {
        dbConn.Open();

        string sql = @"DELETE FROM CarritoProducte WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", Id);

        int rows = cmd.ExecuteNonQuery();

        dbConn.Close();

        return rows > 0;
    }
}
