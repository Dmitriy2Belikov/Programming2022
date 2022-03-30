using Programming.Core.DataTransfer.Abstractions;

namespace Programming.Core.DataTransfer.Project.Request
{
    public class CreateProjectDto : ICreateDto
    {
        public string Name { get; set; }
        public long TeamId { get; set; }
    }
}
