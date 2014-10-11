namespace SystemDot.Specifications.messenger
{
    public class TestRequestReplyHandler
    {
        public TestReply Handle(TestRequest query)
        {
            return query.Reply;
        }
    }
}