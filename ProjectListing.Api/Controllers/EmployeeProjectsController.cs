using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using ProjectListing.Api.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeProjectsController : ControllerBase
    {
        List<EmployeeProject> _employeeProjects;

        public EmployeeProjectsController()
        {
            _employeeProjects = DataStore.EmployeeProjects;
        }
        // GET: api/<EmployeeProjectsController>
        [HttpGet]
        public ActionResult<IEnumerable<EmployeeProject>> GetEmployeeProjects()
        {
            return Ok(_employeeProjects);
        }

        // GET api/<EmployeeProjectsController>/5
        [HttpGet("employee/{id_Employee}")]
        public ActionResult<EmployeeProject> GetEmployeeProjectsByEmployee(int id_Employee)
        {
            var employeeProjects = DataStore.EmployeeProjects.Where(ep => ep.Id_Employee == id_Employee).ToList();

            if (employeeProjects == null)
            {
                return NotFound();
            }

            return Ok(employeeProjects);
        }

        // GET api/<EmployeeProjectsController>/5
        [HttpGet("project/{id_Project}")]
        public ActionResult<EmployeeProject> GetEmployeeProjectsByProjects(int id_Project)
        {
            var employeeProjects = DataStore.EmployeeProjects.Where(ep => ep.Id_Project == id_Project).ToList();

            if (employeeProjects == null)
            {
                return NotFound();
            }

            return Ok(employeeProjects);
        }

        // POST api/<EmployeeProjectsController>
        [HttpPost]
        public ActionResult<EmployeeProject> AddEmployeeToProject(int id_Employee, int id_Project)
        {
            var employee = DataStore.Employees.FirstOrDefault(e => e.Id == id_Employee);
            var project = DataStore.Projects.FirstOrDefault(p => p.Id == id_Project);

            if (employee == null || project == null)
            {
                return NotFound("Either employee or project not found.");
            }

            if (DataStore.EmployeeProjects.Any(ep => ep.Id_Employee == id_Employee && ep.Id_Project == id_Project))
            {
                return BadRequest("This employee is already assigned to the project.");
            }

            DataStore.EmployeeProjects.Add(new EmployeeProject { Id_Employee = id_Employee, Id_Project = id_Project });

            return Ok();
        }

        // PUT api/<EmployeeProjectsController>/5
        [HttpPut("{id_Employee}/{id_Project}")]
        public ActionResult<EmployeeProject> Put(int id_Employee, int id_Project, [FromBody] EmployeeProject updatedEmployeeProject)
        {
            var employee = DataStore.Employees.FirstOrDefault(e => e.Id == id_Employee);
            var project = DataStore.Projects.FirstOrDefault(p => p.Id == id_Project);

            if (employee == null || project == null)
            {
                return NotFound("Either employee or project not found.");
            }

            var employeeProject = DataStore.EmployeeProjects
                .FirstOrDefault(ep => ep.Id_Employee == id_Employee && ep.Id_Project == id_Project);

            if (employeeProject == null)
            {
                return NotFound("This relationship between employee and project does not exist.");
            }

            employeeProject.Id_Employee = updatedEmployeeProject.Id_Employee;
            employeeProject.Id_Project = updatedEmployeeProject.Id_Project;

            return NoContent();
        }

        // DELETE api/<EmployeeProjectsController>
        [HttpDelete("{id_Employee}/{id_Project}")]
        public ActionResult<EmployeeProject> DeleteEmployeeFromProject(int id_Employee, int id_Project)
        {
            var employeeProject = DataStore.EmployeeProjects
                .FirstOrDefault(ep => ep.Id_Employee == id_Employee && ep.Id_Project == id_Project);

            if (employeeProject == null)
            {
                return NotFound("Employee is not assigned to this project.");
            }

            DataStore.EmployeeProjects.Remove(employeeProject);

            return NoContent();
        }
    }
}
