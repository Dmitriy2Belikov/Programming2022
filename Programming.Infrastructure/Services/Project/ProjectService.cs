using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Programming.Core.Common;
using Programming.Core.DataTransfer.Project.Request;
using Programming.Core.DataTransfer.Project.Response;
using Programming.Core.Domain.Common.ValueObjects;
using Programming.Core.Domain.Project.Enums;
using Programming.Core.Interfaces.Repositories;
using Programming.Core.Interfaces.Services;
using Programming.Core.Interfaces.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Programming.Core.Domain.Project.ValueObjects;
using Programming.Infrastructure.Tools.Filtration.Project;

namespace Programming.Infrastructure.Services.Project
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IProjectFiltrationService _filtrationService;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository repository, IProjectFiltrationService filtrationService, IMapper mapper)
        {
            _repository = repository;
            _filtrationService = filtrationService;
            _mapper = mapper;
        }

        public async Task Create(CreateProjectDto data)
        {
            var name = new Name(data.Name);
            var project = new Core.Domain.Project.Project(name, data.TeamId);

            await _repository.AddAsync(project);
            await _repository.SaveChangesAsync();
        }

        public async Task Update(long id, UpdateProjectDto data)
        {
            var name = new Name(data.Name);
            var project = await _repository.FindAsync(id);
            if (project == null)
            {
                throw new Exception("Project not found");
            }

            project.ChangeName(name);
            project.TeamId = data.TeamId;

            _repository.Update(project);
            await _repository.SaveChangesAsync();
        }

        public async Task Remove(long id)
        {
            var project = await _repository.FindAsync(id);
            if (project == null)
            {
                throw new Exception("Project not found");
            }

            _repository.Remove(project);
            await _repository.SaveChangesAsync();
        }

        public async Task<FullProjectDto> Find(long id)
        {
            var project = await _repository.FindAsync(id);
            if (project == null)
            {
                throw new Exception("Project not found");
            }

            var dto = _mapper.Map<FullProjectDto>(project);

            return dto;
        }

        public async Task<List<ShortProjectDto>> Query(
            FilterCollection<Core.Domain.Project.Project> filterCollection,
            SortDirection sortDirection,
            ProjectSortFields sortField,
            int skip = 0,
            int take = 20)
        {
            var projects = await _repository.GetAll();
            if (projects == null || !projects.Any())
            {
                throw new Exception("Projects not found");
            }

            projects = _filtrationService.ProcessFilter(projects, filterCollection);

            Expression<Func<Core.Domain.Project.Project, object>> sortBy = x => x.Id;
            switch (sortField)
            {
                case ProjectSortFields.Id:
                    sortBy = x => x.Id;
                    break;
                case ProjectSortFields.Name:
                    sortBy = x => x.Name.Value;
                    break;
                case ProjectSortFields.Status:
                    sortBy = x => x.Status.ProjectStatus;
                    break;
                case ProjectSortFields.CreatedDate:
                    sortBy = x => x.CreatedDate;
                    break;
            }

            projects = sortDirection == SortDirection.Ascending
                ? projects.OrderBy(sortBy)
                : projects.OrderByDescending(sortBy);

            projects = projects.Skip(skip).Take(take);

            var dto = await projects
                .ProjectTo<ShortProjectDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return dto;
        }

        public async Task UpdateStatus(long id, ProjectStatus projectStatus)
        {
            var project = await _repository.FindAsync(id);
            if (project is null)
            {
                throw new Exception("Project not found");
            }

            var status = new Status(projectStatus);
            project.ChangeStatus(status);

            _repository.Update(project);
            await _repository.SaveChangesAsync();
        }
    }
}
