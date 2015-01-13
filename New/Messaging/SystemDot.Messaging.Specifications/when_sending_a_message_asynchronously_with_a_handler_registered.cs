using SystemDot.Messaging.Simple;
using FluentAssertions;
using Machine.Specifications;

namespace SystemDot.Messaging.Specifications
{
    [Subject(SpecificationGroup.Description)]
    public class when_sending_a_message_asynchronously_with_a_handler_registered
    {
        static object message;
        static TestAsyncHandler<object> handler;
        static Dispatcher dispatcher;

        Establish context = () =>
        {
            dispatcher = new Dispatcher();
            
            handler = new TestAsyncHandler<object>();
            dispatcher.RegisterHandler(handler);
            message = new object();
        };

        Because of = () => dispatcher.SendAsync(message).Wait();

        It should_handle_the_message = () => handler.HandledMessage.Should().BeSameAs(message);
    }
}