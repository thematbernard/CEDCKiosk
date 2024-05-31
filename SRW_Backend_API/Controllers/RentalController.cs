using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        // GET: api/Rental
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RentalDTO>>> GetAll()
        {
            try
            {
                var rentalDTOs = await _rentalService.GetAllRentals();

                return Ok(rentalDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Rental/{rental_ID}
        [HttpGet("{rental_ID}")]
        public async Task<ActionResult<RentalDTO>> Get(int rental_ID)
        {
            try
            {
                var rentalDTO = await _rentalService.GetRentalById(rental_ID);

                if (rentalDTO == null)
                {
                    return NotFound();
                }

                return Ok(rentalDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Rental
        [HttpPost]
        public async Task<ActionResult<RentalDTO>> Create(RentalDTO newRentalDTO)
        {
            try
            {
                await _rentalService.CreateRental(newRentalDTO);

                return CreatedAtAction(nameof(Get), new { rental_ID = newRentalDTO.Rental_ID }, newRentalDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Rental/{rental_ID}
        [HttpPut("{rental_ID}")]
        public async Task<IActionResult> Update(int rental_ID, RentalDTO newRentalDTO)
        {
            try
            {
                var rentalDTO = await _rentalService.GetRentalById(rental_ID);

                if (rentalDTO == null)
                {
                    return NotFound();
                }

                await _rentalService.UpdateRental(newRentalDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Rental/{rental_ID}
        [HttpDelete("{rental_ID}")]
        public async Task<IActionResult> Delete(int rental_ID)
        {
            try
            {
                var rentalDTO = await _rentalService.GetRentalById(rental_ID);

                if (rentalDTO == null)
                {
                    return NotFound();
                }

                // Remove rental
                await _rentalService.DeleteRental(rental_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
