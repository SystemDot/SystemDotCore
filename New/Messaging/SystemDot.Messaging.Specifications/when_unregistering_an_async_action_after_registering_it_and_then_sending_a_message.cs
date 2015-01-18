using System;
using System.Threading.Tasks;
using SystemDot.Messaging.Handling.Actions.Async;
using SystemDot.Messaging.Simple;
using FluentAssertions;
using Machine.Specifications;

namespace SystemDot.Messaging.Specifications
{
    [Subject(SpecificationGroup.Description)]
    public class when_unregistering_an_async_action_after_registering_it_and_then_sending_a_message
    {
        static object handledMessage;
        static object message;
        static Dispatcher dispatcher;

        Establish context = () =>
        {
            dispatcher = new Dispatcher();
            
            Func<object, Task> action = m =>
            {
                handledMessage = m;
                return Task.FromResult(false);
            };

            AsyncActionHandlerSubscriptionToken<object> token = dispatcher.RegisterHandler(action);
            dispatcher.UnregisterHandler(token);
            message = new object();
        };

        Because of = () => dispatcher.Send(message);

        It should_not_handle_the_message = () => handledMessage.Should().BeNull();
    }
}