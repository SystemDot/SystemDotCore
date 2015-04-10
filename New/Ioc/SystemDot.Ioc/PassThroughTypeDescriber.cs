namespace SystemDot.Ioc
{
    using System;

    public class PassThroughTypeDescriber : ITypeDescriber
    {
        public string Describe(Type actualConcreteType)
        {
            return actualConcreteType.Name;
        }
    }
}