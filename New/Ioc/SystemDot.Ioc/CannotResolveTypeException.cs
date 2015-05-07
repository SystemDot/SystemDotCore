using System;

namespace SystemDot.Ioc
{
    public class CannotResolveTypeException : Exception
    {
        
        public CannotResolveTypeException(Func<Type, string> typeDescriber, Type type, Exception inner) : base(GetMessage(typeDescriber, type), inner)
        {
        }

        static string GetMessage(Func<Type, string> typeDescriber, Type type)
        {
            return string.Format(IocContainerResources.CannotResolveTypeMessage, typeDescriber(type));
        }
    }
}