using Microsoft.AspNetCore.Mvc;
using Programming.Core.Common;
using Programming.Core.DataTransfer.Project.Request;
using Programming.Core.Domain.Project;
using Programming.Core.Domain.Project.Enums;
using Programming.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Programming.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ApiController<CreateProjectDto, UpdateProjectDto>
    {
        private readonly IProjectService _service;

        public ProjectController(
            IProjectService service)
        {
            _service = service;
        }

        [HttpPost]
        public override async Task<IActionResult> Create(CreateProjectDto data)
        {
             await _service.Create(data);

             return Ok();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> Get(long id)
        {
            var project = await _service.Find(id);

            return Ok(project);
        }

        [HttpPut("{id}")]
        public override async Task<IActionResult> Edit(long id, UpdateProjectDto data)
        {
            await _service.Update(id, data);

            return Ok();
        }

        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(long id)
        {
            await _service.Remove(id);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Query(
            SortDirection sortDirection = SortDirection.Ascending,
            ProjectSortFields sortField = ProjectSortFields.Id,
            long? byId = null,
            string byName = null,
            ProjectStatus? byStatus = null,
            DateTime? byCreatedDate = null,
            int skip = 0,
            int take = 20)
        {
            var filterCollection = new FilterCollection<Project>()
                .Add(x => x.Id == byId, byId)
                .Add(x => x.Name.Value.ToLower().Contains(byName.ToLower()), byName)
                .Add(x => x.Status.ProjectStatus == byStatus, byStatus)
                .Add(x => x.CreatedDate == byCreatedDate, byCreatedDate);

            var projects = await _service.Query(filterCollection, sortDirection, sortField, skip, take);

            return Ok(projects);
        }

        [HttpPut("updateStatus/{id}")]
        public async Task<IActionResult> UpdateStatus(long id, ProjectStatus status)
        {
            await _service.UpdateStatus(id, status);

            return Ok();
        }
    }
}
