﻿using System.ComponentModel.DataAnnotations;

namespace ProjectListing.Api.Models.Project
{
    public class CreateProjectDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
    }
}
