using System.ComponentModel.DataAnnotations;

namespace ProjectListing.Api.Models.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Position { get; set; }
    }
}