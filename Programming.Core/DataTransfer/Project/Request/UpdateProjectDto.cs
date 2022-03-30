using Programming.Core.DataTransfer.Abstractions;

namespace Programming.Core.DataTransfer.Project.Request
{
    public class UpdateProjectDto : IUpdateDto
    {
        public string Name { get; set; }
        public long TeamId { get; set; }
    }
}
