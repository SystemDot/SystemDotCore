using SystemDot.Messaging.Simple;
using FluentAssertions;
using Machine.Specifications;

namespace SystemDot.Messaging.Specifications
{
    [Subject(SpecificationGroup.Description)]
    public class when_sending_a_message_with_two_handlers_registered
    {
        static object handledMessage1;
        static object handledMessage2;
        static object message;

        Establish context = () =>
        {
            Messenger.RegisterHandler<object>(m => handledMessage1 = m);
            Messenger.RegisterHandler<object>(m => handledMessage2 = m);

            message = new object();
        };

        Because of = () => Messenger.Send(message);

        It should_handle_the_message_with_the_first_handler = () => handledMessage1.Should().BeSameAs(message);

        It should_handle_the_message_with_the_second_handler = () => handledMessage2.Should().BeSameAs(message);
    }
}