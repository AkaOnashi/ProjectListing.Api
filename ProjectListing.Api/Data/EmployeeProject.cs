namespace ProjectListing.Api.Data
{
    public class EmployeeProject
    {
        public int Id_Project {  get; set; }
        public int Id_Employee { get; set; }

        public Employee Employee { get; set; } = null!;
        public Project Project { get; set; } = null!;

    }
}