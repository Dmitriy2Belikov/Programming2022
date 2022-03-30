using System;
using Programming.Core.DataTransfer.Abstractions;

namespace Programming.Core.DataTransfer.Developer.Response
{
    public class FullDeveloperDto : IFullDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public long? TeamId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
