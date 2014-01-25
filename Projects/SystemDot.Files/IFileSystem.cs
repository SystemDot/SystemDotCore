using System.IO;

namespace SystemDot.Files
{
    public interface IFileSystem
    {
        bool FileExists(string fileName, FileLocation location);
        Stream LoadFile(string fileName, FileLocation location);
    }
}