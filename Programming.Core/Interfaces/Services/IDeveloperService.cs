using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programming.Core.DataTransfer.Developer.Request;
using Programming.Core.DataTransfer.Developer.Response;
using Programming.Core.Domain.Developer;
using Programming.Core.Domain.Developer.Enums;

namespace Programming.Core.Interfaces.Services
{
    public interface IDeveloperService : IService<
        Developer, 
        CreateDeveloperDto, 
        UpdateDeveloperDto, 
        FullDeveloperDto, 
        ShortDeveloperDto, 
        DeveloperSortFields>
    {

    }
}
