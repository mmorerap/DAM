using dbdemo.Model;

namespace dbdemo.Factory;

public class DescompteNormalFactory : IDescompteFactory
{
    public IDescompteTipe CreateDescompte()
    {
        return new DescompteNormal();
    }
}

public class DescomptePrmiumFactory : IDescompteFactory
{
    public IDescompteTipe CreateDescompte()
    {
        return new DescomptePremium();
    }
}