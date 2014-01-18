using System.IO;

namespace SystemDot.Files.Windows
{
    public class FileSystem : IFileSystem
    {
        public bool FileExists(string path)
        {
            return File.Exists(path);
        }
    }
}
