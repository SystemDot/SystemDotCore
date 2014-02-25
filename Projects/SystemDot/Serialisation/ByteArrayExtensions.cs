using System.Text;

namespace SystemDot.Serialisation
{
    public static class ByteArrayExtensions
    {
        public static string GetStringFromUtf8(this byte[] toConvert)
        {
            return Encoding.UTF8.GetString(toConvert, 0, toConvert.Length);
        }
    }
}