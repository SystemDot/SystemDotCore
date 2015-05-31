
namespace SystemDot.Environment
{
    using DeviceInfo.Plugin;

    public class LocalMachine : ILocalMachine
    {
        public string GetName()
        {
            return CrossDeviceInfo.Current.Id;
        }

        public string GetModel()
        {
            return CrossDeviceInfo.Current.Model;
        }

        public string GetVersion()
        {
            return CrossDeviceInfo.Current.Version;
        }
    }
}