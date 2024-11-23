using ProjectListing.Api.Data;
using ProjectListing.Api.Models.Employee;

namespace ProjectListing.Api.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<EmployeeDetailDto> GetEmployeeDetails(int id);
    }
}
