using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/Reservation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetAll()
        {
            try
            {
                var reservationDTOs = await _reservationService.GetAllReservations();

                return Ok(reservationDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Reservation/{reservation_ID}
        [HttpGet("{reservation_ID}")]
        public async Task<ActionResult<ReservationDTO>> Get(int reservation_ID)
        {
            try
            {
                var reservationDTO = await _reservationService.GetReservationById(reservation_ID);

                if (reservationDTO == null)
                {
                    return NotFound();
                }

                return Ok(reservationDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Reservation
        [HttpPost]
        public async Task<ActionResult<ReservationDTO>> Create(ReservationDTO newReservationDTO)
        {
            try
            {
                await _reservationService.CreateReservation(newReservationDTO);

                return CreatedAtAction(nameof(Get), new { reservation_ID = newReservationDTO.Reservation_ID }, newReservationDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Reservation/{reservation_ID}
        [HttpPut("{reservation_ID}")]
        public async Task<IActionResult> Update(int reservation_ID, ReservationDTO newReservationDTO)
        {
            try
            {
                var reservationDTO = await _reservationService.GetReservationById(reservation_ID);

                if (reservationDTO == null)
                {
                    return NotFound();
                }

                await _reservationService.UpdateReservation(newReservationDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Reservation/{reservation_ID}
        [HttpDelete("{reservation_ID}")]
        public async Task<IActionResult> Delete(int reservation_ID)
        {
            try
            {
                var reservationDTO = await _reservationService.GetReservationById(reservation_ID);

                if (reservationDTO == null)
                {
                    return NotFound();
                }

                // Remove reservation
                await _reservationService.DeleteReservation(reservation_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
