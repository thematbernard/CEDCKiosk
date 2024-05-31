using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly IResourceService _resourceService;

        public ImageController(IImageService imageService, IResourceService resourceService)
        {
            _imageService = imageService;
            _resourceService = resourceService;
        }

        // GET: api/Image
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageDTO>>> GetAll()
        {
            try
            {
                var imageDTOs = await _imageService.GetAllImages();
                
                return Ok(imageDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Image/{image_ID}
        [HttpGet("{image_ID}")]
        public async Task<ActionResult<ImageDTO>> Get(int image_ID)
        {
            try
            {
                var imageDTO = await _imageService.GetImageById(image_ID);

                if (imageDTO == null)
                {
                    return NotFound();
                }
                
                return Ok(imageDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Image
        [HttpPost]
        public async Task<ActionResult<ImageDTO>> Create(ImageDTO newImageDTO)
        {
            try
            {
                await _imageService.CreateImage(newImageDTO);

                return CreatedAtAction(nameof(Get), new { image_ID = newImageDTO.Image_ID }, newImageDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Image/{image_ID}
        [HttpPut("{image_ID}")]
        public async Task<IActionResult> Update(int image_ID, ImageDTO newImageDTO)
        {
            try
            {
                var imageDTO = await _imageService.GetImageById(image_ID);

                if (imageDTO == null)
                {
                    return NotFound();
                }

                await _imageService.UpdateImage(newImageDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Image/{image_ID}
        [HttpDelete("{image_ID}")]
        public async Task<IActionResult> Delete(int image_ID)
        {
            try
            {
                var imageDTO = await _imageService.GetImageById(image_ID);

                if (imageDTO == null)
                {
                    return NotFound();
                }

                // Remove associated resources first
                await _resourceService.DeleteResourceByImage(image_ID);

                // Remove image
                await _imageService.DeleteImage(image_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}