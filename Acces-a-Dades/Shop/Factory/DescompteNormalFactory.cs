using dbdemo.Model;
namespace dbdemo.Factory;

public class DescompteNormalFactory : IDescompteFactory
{
    public IDescompteTipe CreateDescompte()
    {
        return new DescompteNormal();
    }
}