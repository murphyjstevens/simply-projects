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
        private readonly IProjectRepository _projectRepository;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(IProjectRepository projectRepository, ILogger<ProjectController> logger)
        {
            _projectRepository = projectRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("projects")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Project> projects = await _projectRepository.Get();
            return Ok(projects);
        }

        [HttpGet]
        [Route("projects/calculated")]
        public async Task<IActionResult> GetCalculated()
        {
            IEnumerable<Project> projects = await _projectRepository.GetCalculated();
            return Ok(projects);
        }
    }
}