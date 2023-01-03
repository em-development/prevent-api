namespace Application.Wrappers
{
    public class FilterParams
    {
        public int Current { get; set; } = 0;
        public int Limit { get; set; } = 25;
        public string? OrderBy { get; set; }
        public string? OrderDirection { get; set; }
    }
}