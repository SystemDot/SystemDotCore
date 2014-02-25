using System;
using System.Diagnostics.Contracts;
using SystemDot.Environment;

namespace SystemDot.Http
{
    public class ServerAddress
    {
        static ILocalMachine provider;

        public static void SetLocalMachine(ILocalMachine toSet)
        {
            provider = toSet;
        }

        public static ServerAddress Local
        {
            get { return new ServerAddress(provider.GetName(), false); }
        }

        public string Path { get; set; }

        public bool IsSecure { get; set; }

        public ServerAddress()
        {
        }

        public ServerAddress(string path, bool isSecure)
        {
            Contract.Requires(!String.IsNullOrEmpty(path));

            Path = path;
            IsSecure = isSecure;
        }

        public override string ToString()
        {
            return String.Concat(Path, IsSecure ? "(Secure)" : string.Empty);
        }
    }
}