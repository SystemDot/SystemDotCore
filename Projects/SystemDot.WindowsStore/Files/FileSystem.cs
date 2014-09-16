using System;
using System.IO;
using Windows.Storage;

namespace SystemDot.Files
{
    public class FileSystem : IFileSystem
    {
        readonly FileLocationDictionary locations;

        public FileSystem()
        {
            locations = new FileLocationDictionary();
        }

        public bool FileExists(string fileName, FileLocation location)
        {
            try
            {
                LoadStorageFile(fileName, location);
            }
            catch (FileNotFoundException)
            {
                return false;
            }

            return true;
        }

        public Stream LoadFile(string fileName, FileLocation location)
        {
            return LoadStorageFile(fileName, location)
                .OpenAsync(FileAccessMode.Read)
                .GetAwaiter()
                .GetResult()
                .AsStream();
        }

        public void CreateFile(string fileName, FileLocation location)
        {
            GetStorageFolder(location)
                .CreateFileAsync(fileName)
                .GetAwaiter()
                .GetResult();
        }

        public string GetPath(string fileName, FileLocation location)
        {
            return Path.Combine(GetStorageFolder(location).Path, fileName);
        }

        StorageFile LoadStorageFile(string fileName, FileLocation location)
        {
            return GetStorageFolder(location)
                .GetFileAsync(fileName)
                .GetAwaiter()
                .GetResult();
        }

        StorageFolder GetStorageFolder(FileLocation location)
        {
            return locations.GetLocation(location);
        }
    }
}
