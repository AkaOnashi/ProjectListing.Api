using System.Text.Json.Serialization;

namespace ProjectListing.Api.Models.Employee
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Position { get; set; }
        public string Subdivision { get; set; }

        [JsonIgnore]
        public string Status { get; set; } = "Active";


    }
}