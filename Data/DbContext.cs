using System.Data.Entity;
using StudentEnrollment.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base("DefaultConnection") { }

    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseHistory>CoursesHistory { get; set; }
    public DbSet<UserAccount> AccountModel { get; set; }
    public DbSet<Contact> Contacts { get; set; }

    public DbSet<Payment> Payments { get; set; }

    //public DbSet<CourseManagementViewModel> CourseAndHistoryModel { get; set; }
    // Other DbSets...

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseHistory>()
          .HasKey(ch => ch.ID); // Explicitly set primary key

        // Ensure CourseId is not interpreted as a navigation property
        //modelBuilder.Entity<CourseHistory>()
        //    .Property(c)
        //    .HasColumnName("CourseId");
        modelBuilder.Ignore<CourseManagementViewModel>();
        base.OnModelCreating(modelBuilder);
    }
}