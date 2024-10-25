namespace ManuelMap.Filters;

public class StudentFilter : BaseFilter
{
    public string FullName { get; set; } = null!;
    public int Age { get; set; }
}