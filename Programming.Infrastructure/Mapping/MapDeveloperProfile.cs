using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Programming.Core.DataTransfer.Developer.Response;
using Programming.Core.Domain.Developer;

namespace Programming.Infrastructure.Mapping
{
    public class MapDeveloperProfile : Profile
    {
        public MapDeveloperProfile()
        {
            CreateMap<Developer, FullDeveloperDto>()
                .ForMember(x => x.FullName, 
                    x => x.MapFrom(z => z.Name.FullName));

            CreateMap<Developer, ShortDeveloperDto>()
                .ForMember(x => x.FullName,
                    x => x.MapFrom(z => z.Name.FullName));
        }
    }
}
