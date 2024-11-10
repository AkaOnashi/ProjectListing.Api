using AutoMapper;
using ProjectListing.Api.Data;
using ProjectListing.Api.Models.Employee;
using ProjectListing.Api.Models.Project;

namespace ProjectListing.Api.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeDetailDto>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();

            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Project, ProjectDetailDto>().ReverseMap();
            CreateMap<Project, CreateProjectDto>().ReverseMap();
            CreateMap<Project, UpdateProjectDto>().ReverseMap();
        }
    }
}
