using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Mock;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("Projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger<ProjectsController> _logger;

        public ProjectsController(ILogger<ProjectsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<ProjectModel> Get()
        {
            return MockProjects.GetMockProjects();
        }
    }
}