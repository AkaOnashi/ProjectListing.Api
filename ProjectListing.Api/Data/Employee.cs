using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace ProjectListing.Api.Data
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Position { get; set; }
        public string Subdivision { get; set; }
        public string Status { get; set; }

        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
