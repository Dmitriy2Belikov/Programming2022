using System;
using Programming.Core.DataTransfer.Abstractions;

namespace Programming.Core.DataTransfer.Developer.Response
{
    public class ShortDeveloperDto : IShortDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
