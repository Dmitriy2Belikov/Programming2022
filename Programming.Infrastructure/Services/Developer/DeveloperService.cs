using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Programming.Core.Common;
using Programming.Core.DataTransfer.Developer.Request;
using Programming.Core.DataTransfer.Developer.Response;
using Programming.Core.Domain.Common.ValueObjects;
using Programming.Core.Domain.Developer.Enums;
using Programming.Core.Domain.Developer.ValueObjects;
using Programming.Core.Interfaces.Repositories;
using Programming.Core.Interfaces.Services;
using Programming.Infrastructure.Tools.Filtration.Developer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Programming.Infrastructure.Services.Developer
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepository _repository;
        private readonly IDeveloperFiltrationService _filtrationService;
        private readonly IMapper _mapper;

        public DeveloperService(IDeveloperRepository repository, IDeveloperFiltrationService filtrationService, IMapper mapper)
        {
            _repository = repository;
            _filtrationService = filtrationService;
            _mapper = mapper;
        }

        public async Task Create(CreateDeveloperDto data)
        {
            var name = new DeveloperName(new Name(data.FirstName), new Name(data.LastName));
            var developer = new Core.Domain.Developer.Developer(name, data.TeamId);

            await _repository.AddAsync(developer);
            await _repository.SaveChangesAsync();
        }

        public async Task Update(long id, UpdateDeveloperDto data)
        {
            var developer = await _repository.FindAsync(id);
            if (developer == null)
            {
                throw new Exception("Developer not found");
            }

            if (!string.IsNullOrEmpty(data.FirstName) && !string.IsNullOrEmpty(data.LastName))
            {
                var name = new DeveloperName(new Name(data.FirstName), new Name(data.LastName));
                developer.ChangeName(name);
            }

            developer.TeamId = data.TeamId;

            _repository.Update(developer);
            await _repository.SaveChangesAsync();
        }

        public async Task Remove(long id)
        {
            var developer = await _repository.FindAsync(id);
            if (developer == null)
            {
                throw new Exception("Developer not found");
            }

            _repository.Remove(developer);
            await _repository.SaveChangesAsync();
        }

        public async Task<FullDeveloperDto> Find(long id)
        {
            var developer = await _repository.FindAsync(id);
            if (developer == null)
            {
                throw new Exception("Developer not found");
            }

            var dto = _mapper.Map<FullDeveloperDto>(developer);

            return dto;
        }

        public async Task<List<ShortDeveloperDto>> Query(
            FilterCollection<Core.Domain.Developer.Developer> filterCollection, 
            SortDirection sortDirection,
            DeveloperSortFields sortField, 
            int skip = 0, 
            int take = 20)
        {
            var developers = await _repository.GetAll();
            if (developers == null || !developers.Any())
            {
                throw new Exception("Developers not found");
            }

            developers = _filtrationService.ProcessFilter(developers, filterCollection);

            Expression<Func<Core.Domain.Developer.Developer, object>> sortBy = x => x.Id;
            switch (sortField)
            {
                case DeveloperSortFields.Id:
                    sortBy = x => x.Id;
                    break;
                case DeveloperSortFields.Name:
                    sortBy = x => x.Name.FullName;
                    break;
                case DeveloperSortFields.CreatedDate:
                    sortBy = x => x.CreatedDate;
                    break;
            }

            developers = sortDirection == SortDirection.Ascending
                ? developers.OrderBy(sortBy)
                : developers.OrderByDescending(sortBy);

            developers = developers.Skip(skip).Take(take);

            var dto = await developers
                .ProjectTo<ShortDeveloperDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return dto;
        }
    }
}
