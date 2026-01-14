namespace dbdemo.Model;

public class DescompteNormal : IDescompteTipe
{
    public void Execute()
    {
        Console.WriteLine("Client normal.");
    }
}