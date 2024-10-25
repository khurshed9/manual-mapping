namespace ManuelMap.Entities;

public class Student : BaseEntity
{
    public string FullName { get; set; } = null!;

    public int Age { get; set; }

    public string Email { get; set; } = null!;
}