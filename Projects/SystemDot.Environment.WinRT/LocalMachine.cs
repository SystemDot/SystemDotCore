using System.Linq;
using Windows.Networking;
using Windows.Networking.Connectivity;

namespace SystemDot.Environment
{
    public class LocalMachine : ILocalMachine
    {
        public string GetName()
        {
            return NetworkInformation.GetHostNames()
                .First(name => name.Type == HostNameType.DomainName)
                .DisplayName.Split('.')
                .First()
                .ToUpper();
        }
    }
}