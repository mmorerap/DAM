using Microsoft.Data.SqlClient;
using static System.Console;
using dbdemo.Services;
using dbdemo.Model;


namespace dbdemo.Repository;

class FamiliaADO
{
   
    //POST
    public static void Insert(DatabaseConnection dbConn,Familia familia)
    {

        dbConn.Open();

        string sql = @"INSERT INTO Familia (Id, Nom, Descripcio)         
                        VALUES (@Id, @Nom, @Descripcio)";            

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", familia.Id);
        cmd.Parameters.AddWithValue("@Nom", familia.Nom);
        cmd.Parameters.AddWithValue("@Descripcio", familia.Descripcio);

        cmd.ExecuteNonQuery();

        dbConn.Close();
    }

    public static List<Familia> GetAll(DatabaseConnection dbConn)
    {
        List<Familia> familia = new();

        dbConn.Open();
        string sql = "SELECT Id, Nom, Descripcio FROM Familia";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            familia.Add(new Familia
            {
                Id = reader.GetGuid(0),
                Nom = reader.GetString(1),
                Descripcio = reader.GetString(2),
            });
        }

        dbConn.Close();
        return familia;
    }

    public static Familia? GetById(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();
        string sql = "SELECT Id, Nom, Descripcio FROM Familia WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        using SqlDataReader reader = cmd.ExecuteReader();
        Familia? familia = null;

        if (reader.Read())
        {
            familia = new Familia
            {
                Id = reader.GetGuid(0),
                Nom = reader.GetString(1),
                Descripcio = reader.GetString(2),
            };
        }

        dbConn.Close();
        return familia;
    }


     public static void Update(DatabaseConnection dbConn, Familia familia)
    {
        dbConn.Open();

        string sql = @"UPDATE Familia 
                        SET
                        Id = @Id,
                        Nom = @Nom,
                        Descripcio = @Descripcio
                        WHERE Id = @Id";
                        


        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", familia.Id);
        cmd.Parameters.AddWithValue("@Nom", familia.Nom);
        cmd.Parameters.AddWithValue("@Descripcio", familia.Descripcio);

    
        dbConn.Close();
    }
    public static bool Delete(DatabaseConnection dbConn, Guid Id)
    {
        dbConn.Open();

        string sql = @"DELETE FROM Familia WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", Id);

        int rows = cmd.ExecuteNonQuery();

        dbConn.Close();

        return rows > 0;
    }
}
