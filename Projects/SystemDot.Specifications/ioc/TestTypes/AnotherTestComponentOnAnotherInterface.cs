using SystemDot.Specifications.ioc.TestTypes.Interfaces;

namespace SystemDot.Specifications.ioc.TestTypes
{
    public class AnotherTestComponentOnAnotherInterface : IAnotherTestComponent
    {
        public readonly IThirdTestComponent FirstParameter;
        IAnotherTestComponent repeatedComponent;

        public AnotherTestComponentOnAnotherInterface(IThirdTestComponent firstParameter, IAnotherTestComponent repeatedComponent)
        {
            this.FirstParameter = firstParameter;
            this.repeatedComponent = repeatedComponent;
        }
    }
}