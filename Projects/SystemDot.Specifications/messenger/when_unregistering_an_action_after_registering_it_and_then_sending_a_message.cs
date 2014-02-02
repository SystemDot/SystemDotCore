using System;
using SystemDot.Messaging.Simple;
using Machine.Specifications;

namespace SystemDot.Specifications.messenger
{
    [Subject(SpecificationGroup.Description)]
    public class when_unregistering_an_action_after_registering_it_and_then_sending_a_message
    {
        static object handledMessage;
        static object message;

        Establish context = () =>
        {
            Action<object> action = m => handledMessage = m;
            Messenger.RegisterHandler(action);
            Messenger.UnregisterHandler(action);
            message = new object();
        };

        Because of = () => Messenger.Send(message);

        It should_not_handle_the_message = () => handledMessage.ShouldBeNull();
    }
}