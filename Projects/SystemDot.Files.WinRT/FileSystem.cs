using System;
using System.IO;
using SystemDot.Core;
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
