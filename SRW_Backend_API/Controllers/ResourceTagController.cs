using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ResourceTagController : ControllerBase
    {
        private readonly IResourceTagService _resourceTagService;

        public ResourceTagController(IResourceTagService resourceTagService)
        {
            _resourceTagService = resourceTagService;
        }

        // GET: api/ResourceTag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResourceTagDTO>>> GetAll()
        {
            try
            {
                var resourceTagDTOs = await _resourceTagService.GetAllResourceTags();
                
                return Ok(resourceTagDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/ResourceTag/{resource_ID}/{tag_ID}
        [HttpGet("{resource_ID}/{tag_ID}")]
        public async Task<ActionResult<ResourceTagDTO>> Get(int resource_ID, int tag_ID)
        {
            try
            {
                var resourceTagDTO = await _resourceTagService.GetResourceTagById(resource_ID, tag_ID);

                if (resourceTagDTO == null)
                {
                    return NotFound();
                }
                
                return Ok(resourceTagDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/ResourceTag
        [HttpPost]
        public async Task<ActionResult<ResourceTagDTO>> Create(ResourceTagDTO newResourceTagDTO)
        {
            try
            {
                await _resourceTagService.CreateResourceTag(newResourceTagDTO);

                return CreatedAtAction(nameof(Get), new { resource_ID = newResourceTagDTO.Resource_ID, tag_ID = newResourceTagDTO.Tag_ID }, newResourceTagDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ResourceTag/{resource_ID}/{tag_ID}
        [HttpDelete("{resource_ID}/{tag_ID}")]
        public async Task<IActionResult> Delete(int resource_ID, int tag_ID)
        {
            try
            {
                var resourceTagDTO = await _resourceTagService.GetResourceTagById(resource_ID, tag_ID);

                if (resourceTagDTO == null)
                {
                    return NotFound();
                }

                await _resourceTagService.DeleteResourceTag(resource_ID, tag_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
