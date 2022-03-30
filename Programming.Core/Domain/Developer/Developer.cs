using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Programming.Core.Domain.Abstractions;
using Programming.Core.Domain.Developer.ValueObjects;

namespace Programming.Core.Domain.Developer
{
    public class Developer : Entity, IEntityTypeConfiguration<Developer>
    {
        public Developer() { }

        public Developer(DeveloperName developerName, long? teamId = null)
        {
            Name = developerName ?? throw new ArgumentNullException(nameof(developerName));

            TeamId = teamId;
        }

        public void Configure(EntityTypeBuilder<Developer> builder)
        {
            builder.ToTable("Developers");
            builder.OwnsOne(x => x.Name, x =>
            {
                x.OwnsOne(z => z.FirstName, z =>
                {
                    z.Property(n => n.Value).HasColumnName("FirstName");
                });
                x.OwnsOne(z => z.LastName, z =>
                {
                    z.Property(n => n.Value).HasColumnName("LastName");
                });
            });
        }

        public DeveloperName Name { get; private set; }

        public long? TeamId { get; set; }
        public Team.Team Team { get; set; }

        public void ChangeName(DeveloperName name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
