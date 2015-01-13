using SystemDot.Messaging.Simple;
using FluentAssertions;
using Machine.Specifications;

namespace SystemDot.Messaging.Specifications
{
    [Subject(SpecificationGroup.Description)]
    public class when_resetting_the_messenger_after_registering_a_handler_and_then_sending_a_message
    {
        static object handledMessage;
        static object message;
        static Dispatcher dispatcher;

        Establish context = () =>
        {
            dispatcher = new Dispatcher();
            dispatcher.RegisterHandler<object>(m => handledMessage = m);
            dispatcher.Reset();
            message = new object();
        };

        Because of = () => dispatcher.Send(message);

        It should_not_handle_the_message = () => handledMessage.Should().BeNull();
    }
}