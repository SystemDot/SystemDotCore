using System;

namespace SystemDot.Querying
{
    public abstract class IdEqualityBase<T> : IEquatable<T> where T : IdEqualityBase<T>
    {
        public Guid Id { get; set; }

        public bool Equals(T other)
        {
            return Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            return Equals((T)obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(IdEqualityBase<T> left, IdEqualityBase<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IdEqualityBase<T> left, IdEqualityBase<T> right)
        {
            return !Equals(left, right);
        }
    }
}