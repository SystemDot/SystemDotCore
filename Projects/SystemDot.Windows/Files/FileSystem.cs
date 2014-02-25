using System.IO;

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
            return File.Open(fileName, FileMode.Open);
        }
    }
}
