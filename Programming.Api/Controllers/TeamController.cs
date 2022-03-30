using Microsoft.AspNetCore.Mvc;
using Programming.Core.Common;
using Programming.Core.DataTransfer.Team.Request;
using Programming.Core.Domain.Team;
using Programming.Core.Domain.Team.Enums;
using Programming.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Programming.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ApiController<CreateTeamDto, UpdateTeamDto>
    {
        private readonly ITeamService _service;

        public TeamController(ITeamService service)
        {
            _service = service;
        }

        [HttpPost]
        public override async Task<IActionResult> Create(CreateTeamDto data)
        {
            await _service.Create(data);

            return Ok();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> Get(long id)
        {
            var team = await _service.Find(id);

            return Ok(team);
        }

        [HttpPut("{id}")]
        public override async Task<IActionResult> Edit(long id, UpdateTeamDto data)
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
            TeamSortFields sortField = TeamSortFields.Id,
            long? byId = null,
            string byName = null,
            DateTime? byCreatedDate = null,
            int skip = 0,
            int take = 20)
        {
            var filterCollection = new FilterCollection<Team>()
                .Add(x => x.Id == byId, byId)
                .Add(x => x.Name.Value.ToLower().Contains(byName.ToLower()), byName)
                .Add(x => x.CreatedDate == byCreatedDate, byCreatedDate);

            var teams = await _service.Query(filterCollection, sortDirection, sortField, skip, take);

            return Ok(teams);
        }
    }
}
