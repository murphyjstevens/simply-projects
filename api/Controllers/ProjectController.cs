using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _repository;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(IProjectRepository repository, ILogger<ProjectController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [Route("projects")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Project> projects = await _repository.Get();
            return Ok(projects);
        }

        [HttpGet]
        [Route("projects/calculated")]
        public async Task<IActionResult> GetCalculated()
        {
            IEnumerable<Project> projects = await _repository.GetCalculated();
            return Ok(projects);
        }

        [HttpGet]
        [Route("projects/{id}")]
        public async Task<IActionResult> Find(int id)
        {
            Project project = await _repository.Find(id);
            return Ok(project);
        }

        [HttpPost]
        [Route("projects")]
        public async Task<IActionResult> Create(Project project)
        {
            Project newProject = await _repository.Create(project);
            return Ok(newProject);
        }

        [HttpPut]
        [Route("projects")]
        public async Task<IActionResult> Update(Project project)
        {
            Project updatedProject = await _repository.Update(project);
            return Ok(updatedProject);
        }

        [HttpDelete]
        [Route("projects/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}