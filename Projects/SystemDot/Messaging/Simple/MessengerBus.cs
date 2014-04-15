namespace SystemDot.Messaging.Simple
{
    public class MessengerBus : IBus
    {
        public void Publish(object toPublish)
        {
            Messenger.Send(toPublish);
        }

        public void Send(object toSend)
        {
            Messenger.Send(toSend);
        }
    }
}