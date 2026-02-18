using Microsoft.Data.SqlClient;
using static System.Console;
using dbdemo.Services;
using dbdemo.Model;
using dbdemo.DTO;


namespace dbdemo.Repository;

public class JWTADO
{
    public static ClientResponseJWT? GetByDNI(DatabaseConnection dbConn, string dni)
    {
        dbConn.Open();

        string sql = "SELECT ID, Nom, DNI FROM b1botiga.dbo.Client WHERE DNI = @dni";
        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@dni", dni);

        using SqlDataReader reader = cmd.ExecuteReader();
        ClientResponseJWT? client = null;

        if (reader.Read())
        {
            // Por ahora Role fijo igual que tu ejemplo
            client = ClientResponseJWT.FromClient(
                reader.GetGuid(0),
                reader.GetString(1),
                reader.GetString(2),
                "admin"
            );
        }

        dbConn.Close();
        return client;
    }
}