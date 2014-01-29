using System.IO;
using System.Runtime.Serialization;
using SystemDot.Core;

namespace SystemDot.Specifications
{
    public static class StreamExtensions
    {
        public static T Deserialise<T>(this Stream stream, IFormatter formatter)
        {
            stream.Seek(0, 0);
            return formatter.Deserialize(stream).As<T>();
        }

        public static void Serialise(this Stream stream, object toSerialise, IFormatter formatter)
        {
            formatter.Serialize(stream, toSerialise);
            stream.Seek(0, 0);
        }
    }
}