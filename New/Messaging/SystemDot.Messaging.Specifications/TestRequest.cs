namespace SystemDot.Messaging.Specifications
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