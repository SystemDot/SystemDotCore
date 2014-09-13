using SystemDot.Ioc;
using SystemDot.Messaging.Handling;
using SystemDot.Messaging.Simple;
using Machine.Specifications;

namespace SystemDot.Specifications.messenger
{
    [Subject(SpecificationGroup.Description)]
    public class when_sending_a_message_asynchronously_with_a_handler_registered_by_type
    {
        static object message;
        static TestAsyncHandler<object> handler;

        Establish context = () =>
        {
            handler = new TestAsyncHandler<object>();
            var container = new IocContainer();
            container.RegisterInstance<TestAsyncHandler<object>>(() => handler);
            Messenger.RegisterHandlersFromContainer<IAsyncMessageHandler<object>>(container);
            message = new object();
        };

        Because of = async () => await Messenger.SendAsync(message);

        It should_handle_the_message = () => handler.HandledMessage.ShouldBeTheSameAs(message);
    }
}