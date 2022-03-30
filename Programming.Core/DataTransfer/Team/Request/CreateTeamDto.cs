using Programming.Core.DataTransfer.Abstractions;

namespace Programming.Core.DataTransfer.Team.Request
{
    public class CreateTeamDto : ICreateDto
    {
        public string Name { get; set; }
    }
}
