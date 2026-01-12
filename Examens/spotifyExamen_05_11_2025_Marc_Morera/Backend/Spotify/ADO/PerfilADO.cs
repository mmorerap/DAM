using Microsoft.Data.SqlClient;
using Spotify.Model;
using Spotify.Services;


namespace Spotify.Repository;

class PerfilADO
{
    public static void Insert(DatabaseConnection dbConn, Perfil perfil)
    {
        dbConn.Open();

        string sql = @"INSERT INTO Perfils (Id, Name, Descripcio, Estat, User_ID)
                        VALUES (@Id, @Name, @Descripcio, @Estat, @User_ID)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@ID", perfil.Id);
        cmd.Parameters.AddWithValue("@Name", perfil.Name);
        cmd.Parameters.AddWithValue("@Descripcio", perfil.Id);
        cmd.Parameters.AddWithValue("@Estat", perfil.Name);
        cmd.Parameters.AddWithValue("@User_ID", perfil.Id);

        cmd.ExecuteNonQuery();
        dbConn.Close();
    }
    


    public static List<Perfil> GetAll(DatabaseConnection dbConn)
    {
        List<Perfil> perfils = new();

        dbConn.Open();
        string sql = "SELECT Id, Name, Descripcio, Estat, User_ID  FROM Perfils";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            perfils.Add(new Perfil
            {
                Id = reader.GetGuid(0),
                Name = reader.GetString(1),
                Descripcio = reader.GetString(2),
                Estat = reader.GetString(3),
                User_Id = reader.GetGuid(4)

            });
        }
        dbConn.Close();
        return perfils;
    }

    public static Perfil? GetById(DatabaseConnection dbConn, Guid Id)
    {
        dbConn.Open();
        string sql = "SELECT Id, Name, Descripcio, Estat, User_ID FROM Perfils WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", Id);

        using SqlDataReader reader = cmd.ExecuteReader();
        Perfil? perfil = null;

        if (reader.Read())
        {
            perfil = new Perfil
            {
                Id = reader.GetGuid(0),
                Name = reader.GetString(1),
                Descripcio = reader.GetString(2),
                Estat = reader.GetString(3),
                User_Id = reader.GetGuid(4)
            };
        }

        dbConn.Close();
        return perfil;
    }

    public static void Update(DatabaseConnection dbConn, Perfil perfil)
    {
        dbConn.Open();

        string sql = @"UPDATE Perfils 
                        SET Id = @Id,
                        Name = @Name
                        Descripcio = @Descripcio
                        Estat = @Estat
                        User_ID = @User_ID
                        WHERE Id = @Id";
        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", perfil.Id);
        cmd.Parameters.AddWithValue("@Name", perfil.Name);
        cmd.Parameters.AddWithValue("@Descripcio", perfil.Descripcio);
        cmd.Parameters.AddWithValue("@Estat", perfil.Estat);
        cmd.Parameters.AddWithValue("@User_Id", perfil.User_Id);

        int rows = cmd.ExecuteNonQuery();

        // Console.WriteLine($"{rows} fila actualitzada.");

        cmd.ExecuteNonQuery();
        dbConn.Close();
    }

    public static bool Delete(DatabaseConnection dbConn, Guid Id)
    {
        dbConn.Open();

        string sql = @"DELETE FROM Perfils WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", Id);

        int rows = cmd.ExecuteNonQuery();

        dbConn.Close();

        return rows > 0;
    }
}
