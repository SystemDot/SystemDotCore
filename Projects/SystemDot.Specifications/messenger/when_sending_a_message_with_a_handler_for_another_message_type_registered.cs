using SystemDot.Messaging.Simple;
using Machine.Specifications;

namespace SystemDot.Specifications.messenger
{
    [Subject(SpecificationGroup.Description)]
    public class when_sending_a_message_with_a_handler_for_another_message_type_registered 
    {
        static object handledMessage;
        static object message;

        Establish context = () =>
        {
            Messenger.RegisterHandler<int>(m => handledMessage = m);
            message = new object();
        };

        Because of = () => Messenger.Send(message);

        It should_handle_the_message = () => handledMessage.ShouldBeNull();
    }
}