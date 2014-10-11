using SystemDot.Messaging.Simple;
using FluentAssertions;
using Machine.Specifications;

namespace SystemDot.Messaging.Specifications
{
    [Subject(SpecificationGroup.Description)]
    public class when_sending_a_request_expecting_a_reply_with_a_request_reply_handler_registered
    {
        static TestRequest request;
        static TestReply reply;

        Establish context = () =>
        {
            request = new TestRequest();
            Messenger.RegisterHandler(new TestRequestReplyHandler());
        };

        Because of = () => reply = Messenger.SendAndReceiveReply<TestRequest, TestReply>(request);

        It should_handle_the_request_and_return_the_reply = () => reply.Should().BeSameAs(request.Reply);
    }
}