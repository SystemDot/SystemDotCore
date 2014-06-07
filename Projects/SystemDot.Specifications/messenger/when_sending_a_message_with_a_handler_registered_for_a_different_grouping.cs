using SystemDot.Messaging.Simple;
using Machine.Specifications;

namespace SystemDot.Specifications.messenger
{
    [Subject(SpecificationGroup.Description)]
    public class when_sending_a_message_with_a_handler_registered_for_a_different_grouping
    {
        static object handledMessage;
        static object message;
        const int GroupingId = 1;
        const int OtherGroupingId = 2;

        Establish context = () =>
        {
            Messenger.RegisterHandler<object, int>(m => handledMessage = m, GroupingId);
            message = new object();
        };

        Because of = () => Messenger.Send<object, int>(message, OtherGroupingId);

        It should_not_handle_the_message = () => handledMessage.ShouldBeNull();
    }
}