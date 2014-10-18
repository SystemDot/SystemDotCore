namespace SystemDot.Ioc.Specifications.TestTypes
{
    public class TestComponentWithConcreteDependency
    {
        public TestComponent Dependency { get; private set; }

        public TestComponentWithConcreteDependency(TestComponent dependency)
        {
            Dependency = dependency;
        }
    }
}