using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        private readonly IResourceTagService _resourceTagService;

        public ResourceController(IResourceService resourceService, IResourceTagService resourceTagService)
        {
            _resourceService = resourceService;
            _resourceTagService = resourceTagService;
        }

        // GET: api/Resource
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceDTO>>> GetAll()
        {
            try
            {
                var resourceDTOs = await _resourceService.GetAllResources();

                return Ok(resourceDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Resource/{resource_ID}
        [HttpGet("{resource_ID}")]
        public async Task<ActionResult<ResourceDTO>> Get(int resource_ID)
        {
            try
            {
                var resourceDTO = await _resourceService.GetResourceById(resource_ID);

                if (resourceDTO == null)
                {
                    return NotFound();
                }
                
                return Ok(resourceDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Resource
        [HttpPost]
        public async Task<ActionResult<ResourceDTO>> Create(ResourceDTO newResourceDTO)
        {
            try
            {
                await _resourceService.CreateResource(newResourceDTO);

                return CreatedAtAction(nameof(Get), new { resource_ID = newResourceDTO.Resource_ID }, newResourceDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Resource/{resource_ID}
        [HttpPut("{resource_ID}")]
        public async Task<IActionResult> Update(int resource_ID, ResourceDTO newResourceDTO)
        {
            try
            {
                var resourceDTO = await _resourceService.GetResourceById(resource_ID);

                if (resourceDTO == null)
                {
                    return NotFound();
                }

                await _resourceService.UpdateResource(newResourceDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Resource/{resource_ID}
        [HttpDelete("{resource_ID}")]
        public async Task<IActionResult> Delete(int resource_ID)
        {
            try
            {
                var resourceDTO = await _resourceService.GetResourceById(resource_ID);

                if (resourceDTO == null)
                {
                    return NotFound();
                }

                // Remove associations with tags first
                await _resourceTagService.DeleteResourceTagByResource(resource_ID);

                // Remove resource
                await _resourceService.DeleteResource(resource_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}