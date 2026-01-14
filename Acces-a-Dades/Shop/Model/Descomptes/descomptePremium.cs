namespace dbdemo.Model;
public class DescomptePremium : IDescompteTipe
{
    public decimal CalcularDescompte(decimal import)
    {
        return import * 0.10m;
    }
}