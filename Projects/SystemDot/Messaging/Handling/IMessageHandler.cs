using System.Threading.Tasks;

namespace SystemDot.Messaging.Handling
{
    public interface IMessageHandler
    {
    }

    public interface IMessageHandler<in T> : IMessageHandler
    {
        void Handle(T message);
    }

    public interface IAsyncMessageHandler<in T> : IMessageHandler
    {
        Task Handle(T message);
    }
}