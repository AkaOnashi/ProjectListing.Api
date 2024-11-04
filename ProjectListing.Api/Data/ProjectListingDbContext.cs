using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace ProjectListing.Api.Data
{
    public class ProjectListingDbContext : DbContext 
    {
        public ProjectListingDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeProject>()
                .HasKey(ep => new { ep.Id_Project, ep.Id_Employee });

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(e => e.EmployeeProjects)
                .HasForeignKey(ep => ep.Id_Employee);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Project)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(ep => ep.Id_Project);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Ava",
                    Last_Name = "Anko",
                    Position = "Designer",
                    Subdivision = "Design Team",
                    Status = "Active"
                },
                new Employee
                {
                    Id = 2,
                    Name = "Bab",
                    Last_Name = "Benko",
                    Position = ".NET Developer",
                    Subdivision = "Dev Team",
                    Status = "Active"
                },
                new Employee
                {
                    Id = 3,
                    Name = "Cava",
                    Last_Name = "Cenko",
                    Position = "Project Manager",
                    Subdivision = "Managment",
                    Status = "Active"
                }
                );

            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Name = "Project A",
                    Description = "To do some \"A\" things",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(2),
                    Status = "Active"
                },
                new Project
                {
                    Id = 2,
                    Name = "Project B",
                    Description = "To do some \"B\" things very seriously",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1),
                    Status = "Completed"
                });

            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject
                {
                    Id_Employee = 1,
                    Id_Project = 1
                },
                new EmployeeProject
                {
                    Id_Employee = 2,
                    Id_Project = 1
                },
                new EmployeeProject
                {
                    Id_Employee = 1,
                    Id_Project = 2
                }
                );
        }
    }
}
