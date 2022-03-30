using Programming.Core.DataTransfer.Team.Request;
using Programming.Core.DataTransfer.Team.Response;
using Programming.Core.Domain.Team;
using Programming.Core.Domain.Team.Enums;

namespace Programming.Core.Interfaces.Services
{
    public interface ITeamService : IService<
        Team, 
        CreateTeamDto, 
        UpdateTeamDto, 
        FullTeamDto, 
        ShortTeamDto,
        TeamSortFields>
    {
    }
}
