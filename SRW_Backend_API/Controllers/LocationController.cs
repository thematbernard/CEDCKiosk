using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IResourceService _resourceService;

        public LocationController(ILocationService locationService, IResourceService resourceService)
        {
            _locationService = locationService;
            _resourceService = resourceService;
        }

        // GET: api/Location
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDTO>>> GetAll()
        {
            try
            {
                var locationDTOs = await _locationService.GetAllLocations();
                
                return Ok(locationDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Location/{location_ID}
        [HttpGet("{location_ID}")]
        public async Task<ActionResult<LocationDTO>> Get(int location_ID)
        {
            try
            {
                var locationDTO = await _locationService.GetLocationById(location_ID);

                if (locationDTO == null)
                {
                    return NotFound();
                }
                
                return Ok(locationDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Location
        [HttpPost]
        public async Task<ActionResult<LocationDTO>> Create(LocationDTO newLocationDTO)
        {
            try
            {
                await _locationService.CreateLocation(newLocationDTO);

                return CreatedAtAction(nameof(Get), new { location_ID = newLocationDTO.Location_ID }, newLocationDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Location/{location_ID}
        [HttpPut("{location_ID}")]
        public async Task<IActionResult> Update(int location_ID, LocationDTO newLocationDTO)
        {
            try
            {
                var locationDTO = await _locationService.GetLocationById(location_ID);

                if (locationDTO == null)
                {
                    return NotFound();
                }

                await _locationService.UpdateLocation(newLocationDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Location/{id}
        [HttpDelete("{location_ID}")]
        public async Task<IActionResult> Delete(int location_ID)
        {
            try
            {
                var locationDTO = await _locationService.GetLocationById(location_ID);

                if (locationDTO == null)
                {
                    return NotFound();
                }

                // Remove associated resources first
                await _resourceService.DeleteResourceByLocation(location_ID);

                // Remove location
                await _locationService.DeleteLocation(location_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

