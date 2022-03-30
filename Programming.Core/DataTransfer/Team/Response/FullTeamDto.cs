using System;
using Programming.Core.DataTransfer.Abstractions;
using Programming.Core.Domain.Project.Enums;

namespace Programming.Core.DataTransfer.Team.Response
{
    public class FullTeamDto : IFullDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
