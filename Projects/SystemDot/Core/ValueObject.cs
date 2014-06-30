using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace SystemDot.Core
{
    public abstract class ValueObject<T> : Equatable<T> where T : ValueObject<T>
    {
        readonly List<PropertyInfo> properties;

        protected ValueObject()
        {
            properties = new List<PropertyInfo>();
        }

        public override bool Equals(T other)
        {
            foreach (var property in properties)
            {
                var oneValue = property.GetValue(this, null);
                var otherValue = property.GetValue(other, null);

                if (null == oneValue || null == otherValue) return false;
                if (false == oneValue.Equals(otherValue)) return false;
            }

            return true;
        }

        public override Int32 GetHashCode()
        {
            var hashCode = 36;
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(this, null);
                if (null == propertyValue)
                    continue;

                hashCode = hashCode ^ propertyValue.GetHashCode();
            }

            return hashCode;
        }

        public override String ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(this, null);

                if (null == propertyValue)
                    continue;

                stringBuilder.Append(propertyValue);
            }

            return stringBuilder.ToString();
        }

        protected void RegisterProperty(Expression<Func<T, Object>> expression)
        {
            MemberExpression memberExpression;

            if (ExpressionType.Convert == expression.Body.NodeType)
            {
                memberExpression = expression
                    .Body.As<UnaryExpression>()
                    .Operand.As<MemberExpression>();
            }
            else
            {
                memberExpression = expression.Body as MemberExpression;
            }

            if (null == memberExpression)
            {
                throw new InvalidPropertyRegistrationException();
            }

            properties.Add(memberExpression.Member as PropertyInfo);
        }
    }
}