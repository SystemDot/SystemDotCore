using System.IO;
using SystemDot.Serialisation;

namespace SystemDot.Files
{
    public class FileSystem : IFileSystem
    {
        public bool FileExists(string fileName, FileLocation location)
        {
            return File.Exists(fileName);
        }

        public Stream LoadFile(string fileName, FileLocation location)
        {
            return File.ReadAllText(fileName).ToStream();
        }
    }
}
