using System.Collections.Generic;
using System.Linq;
using Api.Mock;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly ILogger<MaterialsController> _logger;

        public MaterialsController(ILogger<MaterialsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Projects/${projectId}/Materials")]
        public IActionResult GetByProjectId(int projectId)
        {
            return Ok(MockMaterials.GetMockMaterials().Where(material => material.ProjectId == projectId));
        }
    }
}