using System.IO;

namespace SystemDot.FileSystem
{
    public interface IFileHelper
    {
        bool FileExists(string fileName, FileLocation location);
        Stream LoadFile(string fileName, FileLocation location);
        void CreateFile(string fileName, FileLocation location);
        string GetPath(string fileName, FileLocation location);
    }
}