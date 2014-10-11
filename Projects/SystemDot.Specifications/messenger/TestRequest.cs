namespace SystemDot.Specifications.messenger
{
    public class TestRequest
    { 
        public TestReply Reply { get; private set; }

        public TestRequest()
        {
            Reply = new TestReply();
        }
    }
}