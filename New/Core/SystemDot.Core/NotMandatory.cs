namespace SystemDot.Core
{
    public class NotMandatory<T>
    {
        public static implicit operator NotMandatory<T>(T from)
        {
            return new NotMandatory<T> { Value = from };
        }

        public T Value { get; private set; }

        public bool HasValue
        {
            get
            {
                return !Equals(default(T), Value);
            }
        }
    }
}