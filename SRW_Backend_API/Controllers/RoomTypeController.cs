using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        // GET: api/RoomType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomTypeDTO>>> GetAll()
        {
            try
            {
                var roomTypeDTOs = await _roomTypeService.GetAllRoomTypes();

                return Ok(roomTypeDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/RoomType/{roomType_ID}
        [HttpGet("{roomType_ID}")]
        public async Task<ActionResult<RoomTypeDTO>> Get(int roomType_ID)
        {
            try
            {
                var roomTypeDTO = await _roomTypeService.GetRoomTypeById(roomType_ID);

                if (roomTypeDTO == null)
                {
                    return NotFound();
                }

                return Ok(roomTypeDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/RoomType
        [HttpPost]
        public async Task<ActionResult<RoomTypeDTO>> Create(RoomTypeDTO newRoomTypeDTO)
        {
            try
            {
                await _roomTypeService.CreateRoomType(newRoomTypeDTO);

                return CreatedAtAction(nameof(Get), new { roomType_ID = newRoomTypeDTO.RoomType_ID }, newRoomTypeDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/RoomType/{roomType_ID}
        [HttpPut("{roomType_ID}")]
        public async Task<IActionResult> Update(int roomType_ID, RoomTypeDTO newRoomTypeDTO)
        {
            try
            {
                var roomTypeDTO = await _roomTypeService.GetRoomTypeById(roomType_ID);

                if (roomTypeDTO == null)
                {
                    return NotFound();
                }

                await _roomTypeService.UpdateRoomType(newRoomTypeDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/RoomType/{roomType_ID}
        [HttpDelete("{roomType_ID}")]
        public async Task<IActionResult> Delete(int roomType_ID)
        {
            try
            {
                var roomTypeDTO = await _roomTypeService.GetRoomTypeById(roomType_ID);

                if (roomTypeDTO == null)
                {
                    return NotFound();
                }

                // Remove roomType
                await _roomTypeService.DeleteRoomType(roomType_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
