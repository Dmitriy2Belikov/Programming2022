using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Programming.Core.Common;
using Programming.Core.DataTransfer.Team.Request;
using Programming.Core.DataTransfer.Team.Response;
using Programming.Core.Domain.Common.ValueObjects;
using Programming.Core.Domain.Team.Enums;
using Programming.Core.Interfaces.Repositories;
using Programming.Core.Interfaces.Services;
using Programming.Infrastructure.Tools.Filtration.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Programming.Infrastructure.Services.Team
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;
        private readonly ITeamFiltrationService _filtrationService;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository repository, ITeamFiltrationService filtrationService, IMapper mapper)
        {
            _repository = repository;
            _filtrationService = filtrationService;
            _mapper = mapper;
        }

        public async Task Create(CreateTeamDto data)
        {
            var name = new Name(data.Name);
            var team = new Core.Domain.Team.Team(name);

            await _repository.AddAsync(team);
            await _repository.SaveChangesAsync();
        }

        public async Task Update(long id, UpdateTeamDto data)
        {
            var name = new Name(data.Name);
            var team = await _repository.FindAsync(id);
            if (team == null)
            {
                throw new Exception("Team not found");
            }

            team.ChangeName(name);

            _repository.Update(team);
            await _repository.SaveChangesAsync();
        }

        public async Task Remove(long id)
        {
            var team = await _repository.FindAsync(id);
            if (team == null)
            {
                throw new Exception("Team not found");
            }

            _repository.Remove(team);
            await _repository.SaveChangesAsync();
        }

        public async Task<FullTeamDto> Find(long id)
        {
            var team = await _repository.FindAsync(id);
            if (team == null)
            {
                throw new Exception("Team not found");
            }

            var dto = _mapper.Map<FullTeamDto>(team);

            return dto;
        }

        public async Task<List<ShortTeamDto>> Query(
            FilterCollection<Core.Domain.Team.Team> filterCollection, 
            SortDirection sortDirection,
            TeamSortFields sortField, 
            int skip = 0, 
            int take = 20)
        {
            var teams = await _repository.GetAll();
            if (teams == null || !teams.Any())
            {
                throw new Exception("Teams not found");
            }

            teams = _filtrationService.ProcessFilter(teams, filterCollection);

            Expression<Func<Core.Domain.Team.Team, object>> sortBy = x => x.Id;
            switch (sortField)
            {
                case TeamSortFields.Id:
                    sortBy = x => x.Id;
                    break;
                case TeamSortFields.Name:
                    sortBy = x => x.Name.Value;
                    break;
                case TeamSortFields.CreatedDate:
                    sortBy = x => x.CreatedDate;
                    break;
            }

            teams = sortDirection == SortDirection.Ascending
                ? teams.OrderBy(sortBy)
                : teams.OrderByDescending(sortBy);

            teams = teams.Skip(skip).Take(take);

            var dto = await teams
                .ProjectTo<ShortTeamDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return dto;
        }
    }
}
