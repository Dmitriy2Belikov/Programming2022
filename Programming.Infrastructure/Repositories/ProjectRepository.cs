using Programming.Core;
using Programming.Core.Domain.Project;
using Programming.Core.Interfaces.Repositories;

namespace Programming.Infrastructure.Repositories
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
