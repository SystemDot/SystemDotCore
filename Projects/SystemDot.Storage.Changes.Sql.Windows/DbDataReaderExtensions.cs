using System.Data.Common;

namespace SystemDot.Storage.Changes.Sql
{
    public static class DbDataReaderExtensions
    {
        public static byte[] GetBytes(this DbDataReader reader, int ordinal)
        {
            long length = reader.GetBytes(ordinal, 0, null, 0, 0);

            var buffer = new byte[length];
            reader.GetBytes(ordinal, 0, buffer, 0, (int)length);

            return buffer;
        }
    }
}