namespace SystemDot.Environment
{
    public interface ILocalMachine
    {
        string GetName();
        string GetModel();
        string GetVersion();
    }
}