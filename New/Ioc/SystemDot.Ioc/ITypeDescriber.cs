namespace SystemDot.Ioc
{
    using System;

    public interface ITypeDescriber
    {
        string Describe(Type actualConcreteType);
    }
}