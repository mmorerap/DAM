using Microsoft.Data.SqlClient;
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
        List<string> roles = new List<string>();

        while (reader.Read())
        {
            if (client == null)
            {
                client = ClientResponseJWT.FromClient(
                    reader.GetGuid(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    roles
                );
            }

            if (!reader.IsDBNull(3))
                roles.Add(reader.GetString(3));
        }

        dbConn.Close();

        return client;
    }
}
