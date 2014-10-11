using System.Threading.Tasks;
using SystemDot.Ioc;

namespace SystemDot.Bootstrapping
{
    public interface IBuildItem
    {
        BuildOrder Order { get; }
        void Build(IIocContainer container);
        Task BuildAsync(IIocContainer container);
    }
}