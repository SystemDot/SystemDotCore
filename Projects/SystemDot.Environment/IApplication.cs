using System.Collections.Generic;
using System.Reflection;

namespace SystemDot.Environment
{
    public interface IApplication
    {
        IEnumerable<Assembly> GetAssemblies();
    }
}