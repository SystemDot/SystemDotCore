namespace SystemDot.Core
{
    public static class ObjectExtensions
    {
        public static T As<T>(this object toCast)
        {
            return (T) toCast;
        }
    }
}