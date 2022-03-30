using Microsoft.Extensions.DependencyInjection;
using Programming.Core.Interfaces.Repositories;
using Programming.Core.Interfaces.Services;
using Programming.Infrastructure.Repositories;
using Programming.Infrastructure.Services.Developer;
using Programming.Infrastructure.Services.Project;
using Programming.Infrastructure.Services.Team;
using Programming.Infrastructure.Tools.Filtration.Developer;
using Programming.Infrastructure.Tools.Filtration.Project;
using Programming.Infrastructure.Tools.Filtration.Team;

namespace Programming.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<IDeveloperRepository, DeveloperRepository>();
            services.AddTransient<IProjectRepository, ProjectRepository>();

            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IDeveloperService, DeveloperService>();

            services.AddTransient<ITeamFiltrationService, TeamFiltrationService>();
            services.AddTransient<IDeveloperFiltrationService, DeveloperFiltrationService>();
            services.AddTransient<IProjectFiltrationService, ProjectFiltrationService>();

            return services;
        }
    }
}
