using SystemDot.Messaging.Simple;

namespace SystemDot.Domain.Commands
{
    public interface ICommandHandler<in T> : IMessageHandler<T>
    {
    }
}