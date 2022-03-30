using System.Collections.Generic;
using System.Threading.Tasks;
using Programming.Core.Common;
using Programming.Core.DataTransfer.Project.Request;
using Programming.Core.DataTransfer.Project.Response;
using Programming.Core.Domain.Project;
using Programming.Core.Domain.Project.Enums;
using Programming.Core.Interfaces.Specifications;

namespace Programming.Core.Interfaces.Services
{
    public interface IProjectService : IService<
        Project, 
        CreateProjectDto, 
        UpdateProjectDto, 
        FullProjectDto, 
        ShortProjectDto, 
        ProjectSortFields>
    {
        Task UpdateStatus(long id, ProjectStatus projectStatus);
    }
}
