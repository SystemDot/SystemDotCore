using SystemDot.Messaging.Simple;
using Machine.Specifications;

namespace SystemDot.Specifications.messenger
{
    [Subject(SpecificationGroup.Description)]
    public class when_sending_a_message_with_a_handler_registered_for_a_particular_grouping
    {
        static object handledMessage;
        static object message;
        const int GroupingId = 1;

        Establish context = () =>
        {
            Messenger.RegisterHandler<object, int>(m => handledMessage = m, GroupingId);
            message = new object();
        };

        Because of = () => Messenger.Send<object, int>(message, GroupingId);

        It should_handle_the_message = () => handledMessage.ShouldBeTheSameAs(message);
    }
}