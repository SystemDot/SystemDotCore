namespace SystemDot.Messaging.Simple
{
    public class MessengerBus : IBus
    {
        public void PublishEvent(object toPublish)
        {
            Messenger.Send(toPublish);
        }

        public void Send(object toSend)
        {
            Messenger.Send(toSend);
        }
    }
}