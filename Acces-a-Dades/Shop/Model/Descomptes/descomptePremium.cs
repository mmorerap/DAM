namespace dbdemo.Model;
public class DescomptePremium : IDescompteTipe
{
    public void Execute()
    {
        Console.WriteLine("Client premium.");
    }
}