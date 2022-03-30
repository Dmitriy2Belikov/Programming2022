using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Programming.Core.Domain.Common.ValueObjects;
using System;
using System.Collections.Generic;
using EntityFrameworkCore.Triggers;
using Programming.Core.Domain.Abstractions;

namespace Programming.Core.Domain.Team
{
    public class Team : Entity, IEntityTypeConfiguration<Team>
    {
        public Team() { }

        public Team(Name name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));

            Developers = new List<Developer.Developer>();
            Projects = new List<Project.Project>();
        }

        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");
            builder.OwnsOne(x => x.Name, x =>
            {
                x.Property(p => p.Value).HasColumnName("Name");
            });
        }

        public Name Name { get; set; }
        public ICollection<Developer.Developer> Developers { get; }
        public ICollection<Project.Project> Projects { get; }

        public void ChangeName(Name name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
