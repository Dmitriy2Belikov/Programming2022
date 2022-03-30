using System;
using Microsoft.EntityFrameworkCore;
using Programming.Core.Domain.Common.ValueObjects;

namespace Programming.Core.Domain.Developer.ValueObjects
{
    [Owned]
    public class DeveloperName
    {
        protected DeveloperName() { }

        public DeveloperName(Name firstName, Name lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }

        public Name FirstName { get; }
        public Name LastName { get; }

        public string FullName => $"{FirstName.Value} {LastName.Value}";

        public override bool Equals(object obj)
        {
            return obj is DeveloperName personalName &&
                   FirstName.Equals(personalName.FirstName) &&
                   LastName.Equals(personalName.LastName) &&
                   FullName.Equals(personalName.FullName);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, FullName);
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}
