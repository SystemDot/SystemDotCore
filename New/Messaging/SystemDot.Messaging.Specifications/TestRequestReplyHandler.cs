namespace SystemDot.Messaging.Specifications
{
    public class TestRequestReplyHandler
    {
        public TestReply Handle(TestRequest query)
        {
            return query.Reply;
        }
    }
}