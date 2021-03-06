using SystemDot.Messaging.Simple;
using Machine.Specifications;

namespace SystemDot.Specifications.messenger
{
    [Subject(SpecificationGroup.Description)]
    public class when_sending_a_message_to_a_registered_handler_that_replies_and_the_reply_is_handled_in_the_call
    {
        static TestReply handledReply;
        static TestRequest request;
        static TestReply reply;

        Establish context = () =>
        {
            request = new TestRequest();
            reply = new TestReply();
            Messenger.RegisterHandler<TestRequest>(m => Messenger.Reply(reply));
        };

        Because of = () => Messenger.Send<TestRequest, TestReply>(request, r => handledReply = r);

        It should_handle_the_response = () => handledReply.ShouldBeTheSameAs(reply);
    }
}