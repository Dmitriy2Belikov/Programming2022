using System;
using Microsoft.EntityFrameworkCore;
using Programming.Core.Domain.Project.Enums;

namespace Programming.Core.Domain.Project.ValueObjects
{
    [Owned]
    public class Status
    {
        protected Status() { }

        public Status(ProjectStatus status)
        {
            ProjectStatus = status;
        }

        public ProjectStatus ProjectStatus { get; }

        public override bool Equals(object obj)
        {
            return obj is Status status &&
                   ProjectStatus.Equals(status.ProjectStatus);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProjectStatus);
        }
    }
}
