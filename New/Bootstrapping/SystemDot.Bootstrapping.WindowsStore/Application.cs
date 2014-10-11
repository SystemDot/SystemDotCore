using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using SystemDot.Reflection;
using Windows.ApplicationModel;
using Windows.Storage;

namespace SystemDot.Bootstrapping
{
    public class Application : IApplication
    {
        public IEnumerable<Type> GetAllTypes()
        {
            return GetAssemblies().SelectMany(a => a.ExportedTypes);
        }

        IEnumerable<Assembly> GetAssemblies()
        {
            return GetAssembliesAsync().GetAwaiter().GetResult();
        }

        async Task<Assembly[]> GetAssembliesAsync()
        {
            return
                (from file
                in await GetAssemblyFiles()
                 where IsLibraryOrExecutable(file)
                 select LoadAssembly(file))
                .ToArray();
        }

        static bool IsLibraryOrExecutable(StorageFile file)
        {
            return file.FileType == ".dll" || file.FileType == ".exe";
        }

        static ConfiguredTaskAwaitable<IReadOnlyList<StorageFile>> GetAssemblyFiles()
        {
            return Package.Current.InstalledLocation.GetFilesAsync().AsTask().ConfigureAwait(false);
        }

        static Assembly LoadAssembly(StorageFile file)
        {
            return Assembly.Load(CreateAssemblyName(file));
        }

        static AssemblyName CreateAssemblyName(StorageFile file)
        {
            return new AssemblyName { Name = Path.GetFileNameWithoutExtension(file.Name) };
        }
    }
}
