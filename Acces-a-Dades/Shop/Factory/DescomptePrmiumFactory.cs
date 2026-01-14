using dbdemo.Model;

namespace dbdemo.Factory;
public class DescomptePrmiumFactory : IDescompteFactory
{
    public IDescompteTipe CreateDescompte()
    {
        return new DescomptePremium();
    }
}