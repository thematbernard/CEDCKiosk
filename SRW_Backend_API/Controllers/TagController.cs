using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IResourceTagService _resourceTagService;

        public TagController(ITagService tagService, IResourceTagService resourceTagService)
        {
            _tagService = tagService;
            _resourceTagService = resourceTagService;
        }

        // GET: api/Tag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagDTO>>> GetAll()
        {
            try
            {
                var tagDTOs = await _tagService.GetAllTags();
                
                return Ok(tagDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Tag/{tag_ID}
        [HttpGet("{tag_ID}")]
        public async Task<ActionResult<TagDTO>> Get(int tag_ID)
        {
            try
            {
                var tagDTO = await _tagService.GetTagById(tag_ID);

                if (tagDTO == null)
                {
                    return NotFound();
                }
                
                return Ok(tagDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Tag
        [HttpPost]
        public async Task<ActionResult<TagDTO>> Create(TagDTO newTagDTO)
        {
            try
            {
                await _tagService.CreateTag(newTagDTO);

                return CreatedAtAction(nameof(Get), new { tag_ID = newTagDTO.Tag_ID }, newTagDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Tag/{tag_ID}
        [HttpPut("{tag_ID}")]
        public async Task<IActionResult> Update(int tag_ID, TagDTO newTagDTO)
        {
            try
            {
                var tagDTO = await _tagService.GetTagById(tag_ID);

                if (tagDTO == null)
                {
                    return NotFound();
                }

                await _tagService.UpdateTag(newTagDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Tag/{tag_ID}
        [HttpDelete("{tag_ID}")]
        public async Task<IActionResult> Delete(int tag_ID)
        {
            try
            {
                var tagDTO = await _tagService.GetTagById(tag_ID);

                if (tagDTO == null)
                {
                    return NotFound();
                }

                // Remove associations with resources first
                await _resourceTagService.DeleteResourceTagByTag(tag_ID);

                // Remove tag
                await _tagService.DeleteTag(tag_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
