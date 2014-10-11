namespace SystemDot.Bootstrapping
{
    internal static class ObjectExtensions
    {
        public static T As<T>(this object toCast)
        {
            return (T)toCast;
        }
    }
}