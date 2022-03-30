using Programming.Core.DataTransfer.Abstractions;

namespace Programming.Core.DataTransfer.Developer.Request
{
    public class UpdateDeveloperDto : IUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long? TeamId { get; set; }
    }
}
