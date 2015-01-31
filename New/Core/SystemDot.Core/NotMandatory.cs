namespace SystemDot.Core
{
    public class NotMandatory<T>
    {
        public static implicit operator NotMandatory<T>(T from)
        {
            return new NotMandatory<T>(from);
        }

        public static NotMandatory<T> NoValue()
        {
            return new NotMandatory<T>(default(T));
        }

        T value;

        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    throw new NotMandatoryHasNoValueException();
                }
                return value;
            }
            set { this.value = value; }
        }

        public NotMandatory(T value)
        {
            this.value = value;
        }

        public bool HasValue
        {
            get
            {
                return !Equals(default(T), value);
            }
        }
    }
}