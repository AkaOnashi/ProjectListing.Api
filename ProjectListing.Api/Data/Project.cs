﻿namespace ProjectListing.Api.Data
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        public ICollection<EmployeeProjects> EmployeeProjects { get; set; }
    }
}
