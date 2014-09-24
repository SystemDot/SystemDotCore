using System;

namespace SystemDot.Ioc
{
    public class ContainerUnverifiableException : Exception
    {
        public ContainerUnverifiableException(Exception inner) : base(
            "Container is unverifiable",
            inner)
        {
        }
    }
}