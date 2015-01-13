using SystemDot.Messaging.Simple;
using FluentAssertions;
using Machine.Specifications;

namespace SystemDot.Messaging.Specifications
{
    [Subject(SpecificationGroup.Description)]
    public class when_sending_a_message_with_a_handler_registered_for_a_particular_grouping
    {
        static object handledMessage;
        static object message;
        const int GroupingId = 1;
        static Dispatcher dispatcher;

        Establish context = () =>
        {
            dispatcher = new Dispatcher();
            dispatcher.RegisterHandler<object, int>(m => handledMessage = m, GroupingId);
            message = new object();
        };

        Because of = () => dispatcher.Send<object, int>(message, GroupingId);

        It should_handle_the_message = () => handledMessage.Should().BeSameAs(message);
    }
}