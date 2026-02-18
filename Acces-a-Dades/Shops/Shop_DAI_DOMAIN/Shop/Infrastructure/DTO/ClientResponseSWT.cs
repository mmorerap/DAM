namespace dbdemo.DTO;

public record ClientResponseJWT(Guid Id, string Nom, string DNI, List<string> Roles)
{
    public static ClientResponseJWT FromClient(Guid id, string nom, string dni, List<string> roles)
    {
        return new ClientResponseJWT(id, nom, dni, roles);
    }
}
