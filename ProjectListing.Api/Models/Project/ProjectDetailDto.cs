namespace ProjectListing.Api.Models.Project
{
    public class ProjectDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        public List<int> Employees { get; set; }
    }
}
