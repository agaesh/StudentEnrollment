using System.Data.Entity;
using StudentEnrollment.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base("DefaultConnection") { }

    public DbSet<Course> Courses { get; set; }
    // Other DbSets...
}