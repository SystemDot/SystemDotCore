using SystemDot.Ioc.Specifications.TestTypes.Interfaces;

namespace SystemDot.Ioc.Specifications.TestTypes
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