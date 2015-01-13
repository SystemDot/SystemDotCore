using SystemDot.Messaging.Simple;
using FluentAssertions;
using Machine.Specifications;

namespace SystemDot.Messaging.Specifications
{
    [Subject(SpecificationGroup.Description)]
    public class when_sending_a_message_to_a_registered_handler_that_replies_and_the_reply_is_handled_in_the_call
    {
        static TestReply handledReply;
        static TestRequest request;
        static TestReply reply;
        static Dispatcher dispatcher;

        Establish context = () =>
        {
            dispatcher = new Dispatcher();
            
            request = new TestRequest();
            reply = new TestReply();
            dispatcher.RegisterHandler<TestRequest>(m => dispatcher.Reply(reply));
        };

        Because of = () => dispatcher.Send<TestRequest, TestReply>(request, r => handledReply = r);

        It should_handle_the_response = () => handledReply.Should().BeSameAs(reply);
    }
}