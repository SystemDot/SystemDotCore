namespace SystemDot.Environment
{
    public class LocalMachine : ILocalMachine
    {
        public string GetName()
        {
            return System.Environment.MachineName;
        }
    }
}