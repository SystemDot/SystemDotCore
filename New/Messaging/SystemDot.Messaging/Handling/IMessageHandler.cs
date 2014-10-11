using System.Threading.Tasks;

namespace SystemDot.Messaging.Handling
{
    public interface IMessageHandler<in T>
    {
        void Handle(T message);
    }

    public interface IAsyncMessageHandler<in T>
    {
        Task Handle(T message);
    }
}