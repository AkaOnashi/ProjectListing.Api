using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using ProjectListing.Api.Data;
using ProjectListing.Api.Models.Employee;

namespace ProjectListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProjectListingDbContext _context;

        public EmployeesController(ProjectListingDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();

            var records = _mapper.Map<List<EmployeeDto>>(employees);
            return Ok(records);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetailDto>> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            var record = _mapper.Map<EmployeeDetailDto>(employee);
            return Ok(employee);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var employee = _mapper.Map<Employee>(createEmployeeDto);

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> PutEmployee(int id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            if(id != updateEmployeeDto.Id)
            {
                return BadRequest();
            }

            var employee = await _context.Employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            _mapper.Map(updateEmployeeDto, employee);

            //_context.Entry(employee).State = EntityState.Modified;

            try
            {
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!EmployeeExist(id))
                {
                    return NotFound(id);
                }
                else
                {
                    throw;
                }
            }
            
            return NoContent();
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool EmployeeExist(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
