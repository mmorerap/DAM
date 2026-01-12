public interface IDescompte
{
    void Start();
}
public class DescompteNormal : IDescompte
{
    public void Start()
    {
        Console.WriteLine("Client normal.");
    }
}

public class DescomptePremium : IDescompte
{
    public void Start()
    {
        Console.WriteLine("Client premium.");
    }
}