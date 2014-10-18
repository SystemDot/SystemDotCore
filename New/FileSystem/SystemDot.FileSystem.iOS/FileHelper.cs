using System.IO;
using SystemDot.Serialisation;

namespace SystemDot.FileSystem
{
    public class FileHelper : IFileHelper
    {
        public bool FileExists(string fileName, FileLocation location)
        {
            return File.Exists(GetPath(fileName, location));
        }

        public Stream LoadFile(string fileName, FileLocation location)
        {
            return File.ReadAllText(GetPath(fileName, location)).ToStream();
        }

        public void CreateFile(string fileName, FileLocation location)
        {
            File.Create(GetPath(fileName, location));
        }

        public string GetPath(string fileName, FileLocation location)
        {
            return fileName;
        }
    }
}
