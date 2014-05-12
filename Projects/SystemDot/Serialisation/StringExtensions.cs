using System.IO;
using System.Text;

namespace SystemDot.Serialisation
{
    public static class StringExtensions
    {
        public static byte[] ToBytes(this string toConvert)
        {
            return Encoding.UTF8.GetBytes(toConvert);
        }

        public static Stream ToStream(this string toConvert)
        {
            var stream = new MemoryStream();

            var writer = new StreamWriter(stream);
            writer.Write(toConvert);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }
    }
}