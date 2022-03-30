namespace Programming.Core.DataTransfer.Abstractions
{
    public interface IFilterDto
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
