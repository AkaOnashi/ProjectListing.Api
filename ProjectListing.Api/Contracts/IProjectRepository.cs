using ProjectListing.Api.Data;
using ProjectListing.Api.Models.Project;

namespace ProjectListing.Api.Contracts
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<ProjectDetailDto> GetProjectDetails(int id);
    }
}
