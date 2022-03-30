using System;
using EntityFrameworkCore.Triggers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Programming.Core.Domain.Abstractions;
using Programming.Core.Domain.Common.ValueObjects;
using Programming.Core.Domain.Project.Enums;
using Programming.Core.Domain.Project.ValueObjects;

namespace Programming.Core.Domain.Project
{
    public class Project : Entity, IEntityTypeConfiguration<Project>
    {
        public Project() { }

        public Project(Name name, long teamId)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));

            Status = new Status(ProjectStatus.Designing);
            TeamId = teamId;
        }

        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");

            builder.OwnsOne(x => x.Name, x =>
            {
                x.Property(z => z.Value).HasColumnName("Name");
            });
            builder.OwnsOne(x => x.Status, x =>
            {
                x.Property(z => z.ProjectStatus).HasColumnName("Status");
            });
        }

        public Name Name { get; private set; }
        public Status Status { get; private set; }

        public long TeamId { get; set; }
        public Team.Team Team { get; set; }

        public void ChangeName(Name name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void ChangeStatus(Status status)
        {
            Status = status ?? throw new ArgumentNullException(nameof(status));
        }
    }
}
