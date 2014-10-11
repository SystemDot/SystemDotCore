using System.Collections.Generic;
using SystemDot.Messaging.Handling;

namespace SystemDot.Messaging.Specifications
{
    public class TestHandler<T> : IMessageHandler<T>
    {
        public List<T> HandledMessages { get; private set; }

        public TestHandler()
        {
            HandledMessages = new List<T>();
        }

        public void Handle(T message)
        {
            HandledMessages.Add(message);
        }
    }
}