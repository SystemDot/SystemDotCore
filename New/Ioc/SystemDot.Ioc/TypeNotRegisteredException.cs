using System;

namespace SystemDot.Ioc
{
    public class TypeNotRegisteredException : Exception
    {
        public TypeNotRegisteredException(Type type)
            : base(GetMessage(type))
        {
        }

        static string GetMessage(Type type)
        {
            return string.Format(IocContainerResources.TypeHasNotBeenRegisteredMessage, type.Name);
        }
    }
}