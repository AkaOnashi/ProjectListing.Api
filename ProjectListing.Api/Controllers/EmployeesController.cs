using Microsoft.AspNetCore.Mvc;
using ProjectListing.Api.Data;

namespace ProjectListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Ava", Last_Name = "Avro", Position = "Designer", Subdivision = "Design Team", Status = "Active", 
                    EmployeeProjects = new List<EmployeeProject>
                    {
                        new EmployeeProject
                        {
                            Id_Project = 1,
                        }
                    }
            },

            new Employee { Id = 2, Name = "Bava", Last_Name = "Bavro", Position = "Middle .NET Developer", Subdivision = "Dev Team", Status = "Active",
            EmployeeProjects = new List<EmployeeProject>
                    {
                        new EmployeeProject
                        {
                            Id_Project = 1,
                        }
                    }
            }
        };

        // GET: api/<EmployeesController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetEmployees()
        {
            var employees = _employees;
            ;

            foreach(var employee in employees)
            {
                employee.EmployeeProjects.FirstOrDefault(ep => ep.Id_Project == 1);

            }

            return Ok(_employees);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public ActionResult<Employee> PostEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return NotFound();
            }

            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public ActionResult<Employee> PutEmployee(int id, [FromBody] Employee employee)
        {
            var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);

            if(existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Id = employee.Id;
            existingEmployee.Name = employee.Name;
            existingEmployee.Last_Name = employee.Last_Name;
            existingEmployee.Position = employee.Position;
            existingEmployee.Subdivision = employee.Subdivision;
            existingEmployee.Status = employee.Status;

            return NoContent();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public ActionResult<Employee> DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);

            if(employee == null)
            {
                return NotFound();
            }

            _employees.Remove(employee);

            return NoContent();
        }
    }
}
