﻿using Microsoft.AspNetCore.Mvc;
using ProjectListing.Api.Data;

namespace ProjectListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        List<Project> _projects;

        public ProjectsController()
        {
            _projects = DataStore.Projects;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Project>> GetProjects()
        {
            return Ok(_projects);
        }

        // GET api/<ProjectsController>/5
        [HttpGet("{id}")]
        public ActionResult<Project> GetProject(int id)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // POST api/<ProjectsController>
        [HttpPost]
        public ActionResult<Project> PostProject([FromBody] Project project)
        {
            if(project == null)
            {
                return NotFound();
            }

            project.Id = _projects.Max(p => p.Id) + 1;
            _projects.Add(project);

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        // PUT api/<ProjectsController>/5
        [HttpPut("{id}")]
        public ActionResult<Project> PutProject(int id, [FromBody] Project project)
        {
            var existingProject = _projects.FirstOrDefault(p => p.Id == id);

            if (existingProject == null)
            {
                return BadRequest();
            }


            existingProject.Name = project.Name;
            existingProject.Description = project.Description;
            existingProject.StartDate = project.StartDate;
            existingProject.EndDate = project.EndDate;
            existingProject.Status = project.Status;

            return NoContent();
        }

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Project> DeleteProjects(int id)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id);

            if(project == null)
            {
                return NotFound();
            }

            _projects.Remove(project);

            return NoContent();
        }
    }
}
