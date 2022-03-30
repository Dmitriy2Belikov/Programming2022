using System;
using Microsoft.EntityFrameworkCore;

namespace Programming.Core.Domain.Common.ValueObjects
{
    [Owned]
    public class Name
    {
        public string Value { get; }

        protected Name(){}

        public Name(string name)
        {
            if (!IsValid(name))
            {
                throw new ArgumentException("Name is not valid");
            }

            Value = name;
        }

        public static bool IsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public override bool Equals(Object obj)
        {
            return obj is Name other && StringComparer.Ordinal.Equals(Value, other.Value);
        }

        public override int GetHashCode()
        {
            return StringComparer.Ordinal.GetHashCode(Value);
        }
    }
}
