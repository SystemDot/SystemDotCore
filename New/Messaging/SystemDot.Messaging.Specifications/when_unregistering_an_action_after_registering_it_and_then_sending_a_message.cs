using System;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.Messaging.Simple;
using FluentAssertions;
using Machine.Specifications;

namespace SystemDot.Messaging.Specifications
{
    [Subject(SpecificationGroup.Description)]
    public class when_unregistering_an_action_after_registering_it_and_then_sending_a_message
    {
        static object handledMessage;
        static object message;

        Establish context = () =>
        {
            Action<object> action = m => handledMessage = m;
            ActionSubscriptionToken<object> token = Messenger.RegisterHandler(action);
            Messenger.UnregisterHandler(token);
            message = new object();
        };

        Because of = () => Messenger.Send(message);

        It should_not_handle_the_message = () => handledMessage.Should().BeNull();
    }
}