namespace dbdemo.Model;

public class Descompte
{
    private readonly IDescompteTipe _Descompte;

    public Descompte(IDescompteTipe descompte)
    {
        _Descompte = descompte;
    }

    public void CrearDescompte()
    {
        _Descompte.Execute();
    }

}