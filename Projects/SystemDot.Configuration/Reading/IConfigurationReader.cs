using System.Collections.Generic;
using System.Xml.Linq;

namespace SystemDot.Configuration.Reading
{
    public interface IConfigurationReader
    {
        void Load(string fileName);
        IEnumerable<XElement> GetSettingsInSection(string section);
    }
}