using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using ProjectListing.Api.Contracts;
using ProjectListing.Api.Data;
using ProjectListing.Api.Models.Employee;

namespace ProjectListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper) 
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var records = _mapper.Map<List<EmployeeDto>>(employees);
            return Ok(records);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetailDto>> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeDetails(id);

            if (employee == null)
            {
                return NotFound();
            }

            var record = _mapper.Map<EmployeeDetailDto>(employee);
            return Ok(record);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var employee = _mapper.Map<Employee>(createEmployeeDto);

            await _employeeRepository.AddAsync(employee);

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

            var employee = await _employeeRepository.GetAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            _mapper.Map(updateEmployeeDto, employee);

            //_context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _employeeRepository.UpdateAsync(employee);
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!await EmployeeExist(id))
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
            await _employeeRepository.DeleteAsync(id);

            return NoContent();
        }
        private Task<bool> EmployeeExist(int id)
        {
            return _employeeRepository.Exists(id);
        }
    }
}
