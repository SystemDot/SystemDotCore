using System;

namespace SystemDot.Ioc
{
    public class RegisteredType
    {
        public Type ResolveBy { get; private set; }

        public Type ActualConcreteType { get; private set; }

        public RegisteredType(Type resolveBy, Type actualConcreteType)
        {
            ResolveBy = resolveBy;
            ActualConcreteType = actualConcreteType;
        }
    }
}