namespace dbdemo.Model;
public class DescompteNormal : IDescompteTipe
{
    public decimal CalcularDescompte(decimal import)
    {
        return import * 0.05m;
    }
}