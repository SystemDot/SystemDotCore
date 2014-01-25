using System.Collections.Generic;
using SystemDot.Core;
using Windows.ApplicationModel;
using Windows.Storage;

namespace SystemDot.Files
{
    public class FileLocationDictionary : Dictionary<int, StorageFolder>
    {
        public FileLocationDictionary()
        {
            Add(FileLocation.InstallLocation.As<int>(), Package.Current.InstalledLocation);
            Add(FileLocation.UserDataLocation.As<int>(), ApplicationData.Current.LocalFolder);
        }

        public StorageFolder GetLocation(FileLocation location)
        {
            return this[location.As<int>()];
        }
    }
}