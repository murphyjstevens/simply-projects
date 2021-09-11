using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Models;
using Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialRepository _repository;
        private readonly ILogger<MaterialController> _logger;

        public MaterialController(IMaterialRepository repository, ILogger<MaterialController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [Route("projects/{projectId}/materials")]
        public async Task<IActionResult> GetByProjectId(int projectId)
        {
            IEnumerable<Material> materials = await _repository.GetByProjectId(projectId);
            return Ok(materials);
        }

        [HttpPost]
        [Route("materials")]
        public async Task<IActionResult> Create(Material material)
        {
            Material newMaterial = await _repository.Create(material);
            return Ok(newMaterial);
        }

        [HttpPut]
        [Route("materials")]
        public async Task<IActionResult> Update(Material material)
        {
            Material updatedMaterial = await _repository.Update(material);
            return Ok(updatedMaterial);
        }

        [HttpDelete]
        [Route("materials/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            return Ok();
        }
    }
}