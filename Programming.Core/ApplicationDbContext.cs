using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameworkCore.Triggers;
using Microsoft.Extensions.DependencyInjection;
using Programming.Core.Domain.Abstractions;
using Programming.Core.Domain.Developer;
using Programming.Core.Domain.Project;
using Programming.Core.Domain.Team;

namespace Programming.Core
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Developer> Developers { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var assembly = Assembly.GetAssembly(typeof(ApplicationDbContext));
            if (assembly != null)
                modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            ConfigureTriggers<Project>();
            ConfigureTriggers<Team>();
            ConfigureTriggers<Developer>();

            Triggers<Team>.Deleting += entry =>
            {
                if (entry.Context is not ApplicationDbContext context)
                {
                    return;
                }

                Task.WaitAll(context.Developers.ForEachAsync(x =>
                {
                    if (x.TeamId != null && x.TeamId == entry.Entity.Id)
                    {
                        x.TeamId = null;
                    }
                }));

                context.Developers.UpdateRange(context.Developers);
            };
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return this.SaveChangesWithTriggersAsync(base.SaveChangesAsync, true, cancellationToken);
        }

        private void ConfigureTriggers<TEntity>()
            where TEntity : Entity
        {
            Triggers<TEntity, ApplicationDbContext>.Inserting += entry =>
            {
                entry.Entity.CreatedDate = DateTime.Now;
                entry.Entity.ModifiedDate = DateTime.Now;
            };

            Triggers<TEntity, ApplicationDbContext>.Updating += entry =>
            {
                entry.Entity.ModifiedDate = DateTime.Now;
            };
        }
    }
}
