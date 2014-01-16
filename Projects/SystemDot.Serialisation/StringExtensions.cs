using System.Text;

namespace SystemDot.Serialisation
{
    public static class StringExtensions
    {
        public static byte[] ToBytes(this string toConvert)
        {
            return Encoding.UTF8.GetBytes(toConvert);
        }
    }
}