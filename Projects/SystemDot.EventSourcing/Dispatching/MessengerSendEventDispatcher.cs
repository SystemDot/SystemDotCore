using SystemDot.Messaging.Simple;

namespace SystemDot.EventSourcing.Dispatching
{
    public class MessengerSendEventDispatcher : IEventDispatcher
    {
        public void Dispatch(object toDispatch)
        {
            Messenger.Send(toDispatch);
        }
    }
}