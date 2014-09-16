using System.IO;

namespace SystemDot.Files
{
    public interface IFileSystem
    {
        bool FileExists(string fileName, FileLocation location);
        Stream LoadFile(string fileName, FileLocation location);
        void CreateFile(string fileName, FileLocation location);
        string GetPath(string fileName, FileLocation location);
    }
}