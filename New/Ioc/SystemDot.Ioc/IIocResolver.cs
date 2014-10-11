using System;

namespace SystemDot.Ioc
{
    public interface IIocResolver
    {
        TPlugin Resolve<TPlugin>();

        object Resolve(Type type);

        bool ComponentExists<TPlugin>();

        bool ComponentExists(Type toCheck);
    }
}