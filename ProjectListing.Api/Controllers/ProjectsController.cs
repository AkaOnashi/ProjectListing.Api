using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectListing.Api.Contracts;
using ProjectListing.Api.Data;
using ProjectListing.Api.Models.Project;
using System.Diagnostics;

namespace ProjectListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        public ProjectsController(IMapper mapper, IProjectRepository projectRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {
            var projects = await _projectRepository.GetAllAsync();

            var records = _mapper.Map<List<ProjectDto>>(projects);
            return Ok(records);
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public async Task <ActionResult<ProjectDetailDto>> GetProject(int id)
        {
            var project = await _projectRepository.GetProjectDetails(id);

            if (project == null)
            {
                return NotFound();
            }

            var record = _mapper.Map<ProjectDetailDto>(project);
            return Ok(record);
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject([FromBody] CreateProjectDto createProjectDto)
        {
            await Console.Out.WriteLineAsync(ModelState.ToString());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Повертає деталі помилок
            }

            var project = _mapper.Map<Project>(createProjectDto);

            await _projectRepository.AddAsync(project);

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        // PUT api/<ProjectsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> PutProject(int id, [FromBody] UpdateProjectDto updateProjectDto)
        {
            if (id != updateProjectDto.Id)
            {
                return BadRequest();
            }

            var project = await _projectRepository.GetAsync(id);

            if(project == null)
            {
                return NotFound();
            }

            _mapper.Map(updateProjectDto, project);

            try
            {
                await _projectRepository.UpdateAsync(project);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProjectExist(id))
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

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProjects(int id)
        {
            await _projectRepository.DeleteAsync(id);

            return NoContent();
        }
        private async Task<bool> ProjectExist(int id)
        {
            return await _projectRepository.Exists(id);
        }
    }
}
