using System;

namespace SystemDot.Ioc
{
    public class CannotResolveTypeException : Exception
    {
        public CannotResolveTypeException(Type type, Exception inner) : base(GetMessage(type), inner)
        {
        }

        static string GetMessage(Type type)
        {
            return string.Format(IocContainerResources.CannotResolveTypeMessage, type.Name);
        }
    }
}