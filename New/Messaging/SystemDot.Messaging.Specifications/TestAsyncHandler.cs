using System;
using System.Threading.Tasks;
using SystemDot.Messaging.Handling;

namespace SystemDot.Messaging.Specifications
{
    public class TestAsyncHandler<T> : IAsyncMessageHandler<T>
    {
        public T HandledMessage { get; private set; }

        public async Task Handle(T message)
        {
            HandledMessage = message;
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }
}