using Microsoft.AspNetCore.Mvc;
using Programming.Core.Common;
using Programming.Core.DataTransfer.Developer.Request;
using Programming.Core.Domain.Developer;
using Programming.Core.Domain.Developer.Enums;
using Programming.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace Programming.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ApiController<CreateDeveloperDto, UpdateDeveloperDto>
    {
        private readonly IDeveloperService _service;

        public DeveloperController(IDeveloperService service)
        {
            _service = service;
        }

        [HttpPost]
        public override async Task<IActionResult> Create(CreateDeveloperDto data)
        {
            await _service.Create(data);

            return Ok();
        }

        [HttpGet("{id}")]
        public override async Task<IActionResult> Get(long id)
        {
            var developer = await _service.Find(id);

            return Ok(developer);
        }

        [HttpPut("{id}")]
        public override async Task<IActionResult> Edit(long id, UpdateDeveloperDto data)
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
            DeveloperSortFields sortField = DeveloperSortFields.Id,
            long? byId = null,
            string byName = null,
            DateTime? byCreatedDate = null,
            int skip = 0,
            int take = 20)
        {
            var filterCollection = new FilterCollection<Developer>()
                .Add(x => x.Id == byId, byId)
                .Add(x => x.Name.FullName.ToLower().Contains(byName.ToLower()), byName)
                .Add(x => x.CreatedDate == byCreatedDate, byCreatedDate);

            var developers = await _service.Query(filterCollection, sortDirection, sortField, skip, take);

            return Ok(developers);
        }
    }
}
