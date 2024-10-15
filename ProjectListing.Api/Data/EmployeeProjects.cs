namespace ProjectListing.Api.Data
{
    public class EmployeeProjects
    {
        public int Id_Project {  get; set; }
        public Project Projet { get; set; }
        public int Id_Employee { get; set; }
        public Employee Employee { get; set; }
    }
}