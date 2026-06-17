
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Api_ITI.Models
{
    public class apiDbContext : IdentityDbContext<ApplicationUser>
    {
        public apiDbContext(DbContextOptions<apiDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "Website Redesign", Description = "Redesign company website" },
                new Project { Id = 2, Name = "Mobile App", Description = "Build Android & iOS app" },
                new Project { Id = 3, Name = "ERP System", Description = "Internal management system" }
            );

          
            modelBuilder.Entity<Employee>()
                .Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FullName = "Mohamed Taha", PhoneNumber = "01012345678", Salary = 8000, Position = "Developer", Department = "IT", ProjectId = 1 },
                new Employee { Id = 2, FullName = "Nour Khaled", PhoneNumber = "01098765432", Salary = 7000, Position = "Tester", Department = "IT", ProjectId = 1 },
                new Employee { Id = 3, FullName = "Hana Sami", PhoneNumber = "01123456789", Salary = 9000, Position = "Designer", Department = "IT", ProjectId = 2 },
                new Employee { Id = 4, FullName = "Tarek Adel", PhoneNumber = "01234567890", Salary = 11000, Position = "Manager", Department = "HR", ProjectId = 3 }
            );
        }

    }
}
