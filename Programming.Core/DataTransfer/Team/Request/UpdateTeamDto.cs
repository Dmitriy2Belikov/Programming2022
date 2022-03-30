using Programming.Core.DataTransfer.Abstractions;

namespace Programming.Core.DataTransfer.Team.Request
{
    public class UpdateTeamDto : IUpdateDto
    {
        public string Name { get; set; }
    }
}
