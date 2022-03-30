using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Programming.Core.DataTransfer.Team.Response;
using Programming.Core.Domain.Team;

namespace Programming.Infrastructure.Mapping
{
    public class MapTeamProfile : Profile
    {
        public MapTeamProfile()
        {
            CreateMap<Team, FullTeamDto>()
                .ForMember(x => x.Name, 
                    x => x.MapFrom(z => z.Name.Value));

            CreateMap<Team, ShortTeamDto>()
                .ForMember(x => x.Name,
                    x => x.MapFrom(z => z.Name.Value));
        }
    }
}
