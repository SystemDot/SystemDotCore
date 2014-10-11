using SystemDot.Messaging.Simple;
using FluentAssertions;
using Machine.Specifications;

namespace SystemDot.Messaging.Specifications
{
    [Subject(SpecificationGroup.Description)]
    public class when_sending_a_message_with_a_handler_registered
    {
        static object handledMessage;
        static object message;

        Establish context = () =>
        {
            Messenger.RegisterHandler<object>(m => handledMessage = m);
            message = new object();
        };

        Because of = () => Messenger.Send(message);

        It should_handle_the_message = () => handledMessage.Should().BeSameAs(message);
    }
}