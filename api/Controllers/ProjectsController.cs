using System.Collections.Generic;
using System.Linq;
using Api.Mock;
using Api.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(ILogger<ProjectsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Projects")]
        public IActionResult Get()
        {
            return Ok(MockProjects.GetMockProjects());
        }

        [HttpGet]
        [Route("Projects/Calculated")]
        public IActionResult GetCalculated()
        {
            var projects = MockProjects.GetMockProjects();
            var materials = MockMaterials.GetMockMaterials();
            IEnumerable<ProjectCalculatedResponse> response = projects.Select(project => {
                return new ProjectCalculatedResponse(
                    id: project.Id,
                    name: project.Name,
                    totalCost: materials.Where(material => material.ProjectId == project.Id).Sum(material => material.Cost * material.Quantity),
                    description: project.Description);
            });
            return Ok(response);
        }
    }
}