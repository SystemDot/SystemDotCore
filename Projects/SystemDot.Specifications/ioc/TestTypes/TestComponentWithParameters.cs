namespace SystemDot.Specifications.ioc.TestTypes
{
    class TestComponentWithParameters : ITestComponentWithParameters
    {
        public readonly ITestComponent FirstParameter;
        public readonly IAnotherTestComponent SecondParameter;

        public TestComponentWithParameters(ITestComponent firstParameter, IAnotherTestComponent secondParameter)
        {
            FirstParameter = firstParameter;
            SecondParameter = secondParameter;
        }
    }
}