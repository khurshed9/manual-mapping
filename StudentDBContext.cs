using ManuelMap.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManuelMap;

public class StudentDBContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
    { }
}