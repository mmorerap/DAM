using dbdemo.Model;

namespace dbdemo.DTO;

public record ClientResponseJWT(Guid Id, string Nom, string DNI, string Role)
{
    public static ClientResponseJWT FromClient(Guid id, string nom, string dni, string role)
    {
        return new ClientResponseJWT(id, nom, dni, role);
    }
}
