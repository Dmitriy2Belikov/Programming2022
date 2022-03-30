using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Programming.Core.DataTransfer.Project.Response;
using Programming.Core.Domain.Project;

namespace Programming.Infrastructure.Mapping
{
    public class MapProjectProfile : Profile
    {
        public MapProjectProfile()
        {
            CreateMap<Project, FullProjectDto>()
                .ForMember(x => x.Name, 
                    x => x.MapFrom(z => z.Name.Value))
                .ForMember(x => x.Status,
                    x => x.MapFrom(z => z.Status.ProjectStatus));

            CreateMap<Project, ShortProjectDto>()
                .ForMember(x => x.Name,
                    x => x.MapFrom(z => z.Name.Value))
                .ForMember(x => x.Status,
                    x => x.MapFrom(z => z.Status.ProjectStatus));
        }
    }
}
