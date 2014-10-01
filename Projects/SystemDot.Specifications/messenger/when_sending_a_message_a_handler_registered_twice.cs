using SystemDot.Messaging.Simple;
using Machine.Specifications;

namespace SystemDot.Specifications.messenger
{
    [Subject(SpecificationGroup.Description)]
    public class when_sending_a_message_a_handler_registered_twice
    {
        static object message;
        static TestHandler<object> handler;

        Establish context = () =>
        {
            handler = new TestHandler<object>();
            Messenger.RegisterHandler(handler);
            Messenger.RegisterHandler(handler);
            message = new object();
        };

        Because of = () => Messenger.Send(message);

        It should_handle_the_message = () => handler.HandledMessages.Count.ShouldEqual(1);
    }
}