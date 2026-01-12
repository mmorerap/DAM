using Microsoft.Data.SqlClient;
using static System.Console;
using dbdemo.Services;
using dbdemo.Model;

//v1.1

namespace dbdemo.Repository;

class ProductADO
{
   

    public static void Insert(DatabaseConnection dbConn,Product product)
    {

        dbConn.Open();

        string sql = @"INSERT INTO Product (Id, Code,Descripcio,Price,Descompte,IdFamilia,Name)
                        VALUES (@Id, @Code, @Descripcio, @Price, @Descompte, @IdFamilia, @Name)";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", product.Id);
        cmd.Parameters.AddWithValue("@Code", product.Code);
        cmd.Parameters.AddWithValue("@Descripcio", product.Descripcio);
        cmd.Parameters.AddWithValue("@Price", product.Price);
        cmd.Parameters.AddWithValue("@Descompte", product.Descompte);
        cmd.Parameters.AddWithValue("@IdFamilia", product.IdFamilia);
        cmd.Parameters.AddWithValue("@Name", product.Name);

        cmd.ExecuteNonQuery();

        dbConn.Close();
    }

    public static List<Product> GetAll(DatabaseConnection dbConn)
    {
        List<Product> products = new();

        dbConn.Open();
        string sql = "SELECT Id, Code,Descripcio,Price,Descompte,IdFamilia,Name FROM Product";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            products.Add(new Product
            {
                Id = reader.GetGuid(0),
                Code = reader.GetString(1),
                Descripcio = reader.GetString(2),
                Price = reader.GetDecimal(3),
                Descompte = reader.GetDecimal(4),
                IdFamilia = reader.GetGuid(5),
                Name = reader.GetString(6)

            });
        }

        dbConn.Close();
        return products;
    }

    public static Product? GetById(DatabaseConnection dbConn, Guid id)
    {
        dbConn.Open();
        string sql = "SELECT Id, Code,Descripcio,Price,Descompte,IdFamilia,Name FROM Product WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", id);

        using SqlDataReader reader = cmd.ExecuteReader();
        Product? product = null;

        if (reader.Read())
        {
            product = new Product
            {
                 Id = reader.GetGuid(0),
                Code = reader.GetString(1),
                Descripcio = reader.GetString(2),
                Price = reader.GetDecimal(3),
                Descompte = reader.GetDecimal(4),
                IdFamilia = reader.GetGuid(5),
                Name = reader.GetString(6)
            };
        }

        dbConn.Close();
        return product;
    }

     public static void Update(DatabaseConnection dbConn, Product product)
    {
        dbConn.Open();

        string sql = @"UPDATE Product 
                        SET
                        Id = @Id,
                        Code = @Code,
                        Descripcio = @Descripcio,
                        Price = @Price,
                        Descompte = @Descompte,
                        IdFamilia = @IdFamilia,
                        Name = @Name
                        WHERE Id = @Id";


        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", product.Id);
        cmd.Parameters.AddWithValue("@Code", product.Code);
        cmd.Parameters.AddWithValue("@Descripcio", product.Descripcio);
        cmd.Parameters.AddWithValue("@Price", product.Price);
        cmd.Parameters.AddWithValue("@Descompte", product.Descompte);
        cmd.Parameters.AddWithValue("@IdFamilia", product.IdFamilia);
        cmd.Parameters.AddWithValue("@Name", product.Name);

        int rows = cmd.ExecuteNonQuery();

        cmd.ExecuteNonQuery();
        dbConn.Close();
    }
    public static bool Delete(DatabaseConnection dbConn, Guid Id)
    {
        dbConn.Open();

        string sql = @"DELETE FROM Product WHERE Id = @Id";

        using SqlCommand cmd = new SqlCommand(sql, dbConn.sqlConnection);
        cmd.Parameters.AddWithValue("@Id", Id);

        int rows = cmd.ExecuteNonQuery();

        dbConn.Close();

        return rows > 0;
    }


}
