using SystemDot.Messaging.Simple;
using Machine.Specifications;

namespace SystemDot.Specifications.messenger
{
    [Subject(SpecificationGroup.Description)]
    public class when_sending_a_message_to_a_registered_handler_that_replies_and_the_reply_is_handled_in_the_call
    {
        static TestResponse handledResponse;
        static TestRequest request;
        static TestResponse response;

        Establish context = () =>
        {
            request = new TestRequest();
            response = new TestResponse();
            Messenger.RegisterHandler<TestRequest>(m => Messenger.Reply(response));
        };

        Because of = () => Messenger.Send<TestRequest, TestResponse>(request, r => handledResponse = r);

        It should_handle_the_response = () => handledResponse.ShouldBeTheSameAs(response);
    }
}