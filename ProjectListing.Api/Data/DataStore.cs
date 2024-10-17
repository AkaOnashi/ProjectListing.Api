namespace ProjectListing.Api.Data
{
    public class DataStore
    {
        public static List<EmployeeProject> EmployeeProjects = new List<EmployeeProject>
        {
            new EmployeeProject { Id_Employee = 1, Id_Project = 1 },
            new EmployeeProject { Id_Employee = 2, Id_Project = 1 }
        };

        public static List<Project> Projects = new List<Project>
        {
            new Project { Id = 1, Name = "Project A", Description = "Description A", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1), Status = "Active" },
            new Project { Id = 2, Name = "Project B", Description = "Description B", StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(2), Status = "Completed" }
        };

        public static List<Employee> Employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Ava", Last_Name = "Avro", Position = "Designer", Subdivision = "Design Team", Status = "Active" },
            new Employee { Id = 2, Name = "Bava", Last_Name = "Bavro", Position = "Middle .NET Developer", Subdivision = "Dev Team", Status = "Active" }
        };
    }
}