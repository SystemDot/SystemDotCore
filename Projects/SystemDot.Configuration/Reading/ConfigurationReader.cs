using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using SystemDot.Files;

namespace SystemDot.Configuration.Reading
{
    public class ConfigurationReader : IConfigurationReader
    {
        XDocument document;
        readonly IFileSystem fileSystem;

        public ConfigurationReader(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
        }

        public void Load(string fileName)
        {
            document = XDocument.Load(XmlReader.Create(GetStream(fileName)));
        }

        Stream GetStream(string fileName)
        {
            return fileSystem.LoadFile(fileName, FileLocation.InstallLocation);
        }

        public IEnumerable<XElement> GetSettingsInSection(string section)
        {
            return document
                .Descendants()
                .Single(d => d.Name == section)
                    .Descendants();
        }
    }
}