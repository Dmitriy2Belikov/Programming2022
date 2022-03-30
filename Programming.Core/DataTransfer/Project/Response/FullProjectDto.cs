using System;
using Programming.Core.DataTransfer.Abstractions;
using Programming.Core.Domain.Project.Enums;

namespace Programming.Core.DataTransfer.Project.Response
{
    public class FullProjectDto : IFullDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ProjectStatus Status { get; set; }
        public long TeamId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
