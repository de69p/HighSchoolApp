namespace HighSchoolApp.Models;

using Microsoft.EntityFrameworkCore;

public class HighSchoolContext : DbContext
{
    public HighSchoolContext(DbContextOptions<HighSchoolContext> options) 
        : base(options)
    {
    }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Exam> Exams { get; set; }
}

