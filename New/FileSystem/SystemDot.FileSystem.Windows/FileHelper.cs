using System.IO;

namespace SystemDot.FileSystem
{
    public class FileHelper : IFileHelper
    {
        public bool FileExists(string fileName, FileLocation location)
        {
            return File.Exists(fileName);
        }

        public Stream LoadFile(string fileName, FileLocation location)
        {
            return File.Open(fileName, FileMode.Open);
        }

        public void CreateFile(string fileName, FileLocation location)
        {
            File.Create(GetPath(fileName, location));
        }

        public string GetPath(string fileName, FileLocation location)
        {
            return Path.Combine(GetPath(location), fileName);
        }

        static string GetPath(FileLocation location)
        {
            return location == FileLocation.UserDataLocation
                ? System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal)
                : System.Environment.CurrentDirectory;
        }
    }
}
