using Microsoft.Data.SqlClient;
using static System.Console;
using dbdemo.Services;
using dbdemo.Model;
using dbdemo.DTO;

namespace dbdemo.Repository;

class JWTADO
{
    public static ClientResponseJWT? GetByDNI(DatabaseConnection dbConn, string dni)
    {
        dbConn.Open();

        string sql = @"SELECT c.ID, c.Nom, c.DNI, r.Code
                       FROM b1botiga.dbo.Client c
                       LEFT JOIN b1botiga.dbo.ClientRoles cr ON c.ID = cr.Client_ID
                       LEFT JOIN b1botiga.dbo.Roles r ON cr.Role_ID = r.ID
                       WHERE c.DNI = @dni";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@dni", dni);

        using SqlDataReader reader = cmd.ExecuteReader();
        ClientResponseJWT? client = null;

        if (reader.Read())
        {
            client = ClientResponseJWT.FromClient(
                reader.GetGuid(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.IsDBNull(3) ? "user" : reader.GetString(3)
            );
        }

        dbConn.Close();
        return client;
    }
}