using Microsoft.EntityFrameworkCore;
using ProjectListing.Api.Contracts;
using ProjectListing.Api.Data;
using ProjectListing.Api.Models.Employee;

namespace ProjectListing.Api.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ProjectListingDbContext _context;
        public EmployeeRepository(ProjectListingDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<EmployeeDetailDto> GetEmployeeDetails(int id)
        {
            return await _context.Employees
                .Where(e => e.Id == id)
                .Include(x => x.EmployeeProjects)
                .ThenInclude(ep  => ep.Project)
                .Select(e => new EmployeeDetailDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Last_Name = e.Last_Name,
                    Position = e.Position,
                    Subdivision = e.Subdivision,
                    Status = e.Status,
                    EmployeeProjects = e.EmployeeProjects.Select(ep => ep.Project.Name).ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
