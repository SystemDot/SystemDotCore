using System;
using SystemDot.Messaging.Simple;
using FluentAssertions;
using Machine.Specifications;

namespace SystemDot.Messaging.Specifications
{
    [Subject(SpecificationGroup.Description)]
    public class when_unregistering_an_unregistered_action_and_then_sending_a_message
    {
        static object handledMessage;
        static object message;
        static Dispatcher dispatcher;

        Establish context = () =>
        {
            dispatcher = new Dispatcher();
            Action<object> action = m => handledMessage = m;
            dispatcher.UnregisterHandler(action);
            message = new object();
        };

        Because of = () => dispatcher.Send(message);

        It should_not_handle_the_message = () => handledMessage.Should().BeNull();
    }
}