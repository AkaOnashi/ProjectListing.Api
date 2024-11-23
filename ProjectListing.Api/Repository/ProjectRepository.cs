using Microsoft.EntityFrameworkCore;
using ProjectListing.Api.Contracts;
using ProjectListing.Api.Data;
using ProjectListing.Api.Models.Project;

namespace ProjectListing.Api.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly ProjectListingDbContext _context;
        public ProjectRepository(ProjectListingDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ProjectDetailDto> GetProjectDetails(int id)
        {
            return await _context.Projects
                .Where(p => p.Id == id)
                .Select(p => new ProjectDetailDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    Status = p.Status,
                    Employees = p.EmployeeProjects.Select(ep => ep.Employee.Id).ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
