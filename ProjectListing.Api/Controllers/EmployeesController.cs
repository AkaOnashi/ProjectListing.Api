using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using ProjectListing.Api.Data;

namespace ProjectListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        List<Employee> _employees = new List<Employee>();

        public EmployeesController() 
        {
            
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
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
