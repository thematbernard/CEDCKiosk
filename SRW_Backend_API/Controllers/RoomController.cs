using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/Room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetAll()
        {
            try
            {
                var roomDTOs = await _roomService.GetAllRooms();

                return Ok(roomDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Room/{room_ID}
        [HttpGet("{room_ID}")]
        public async Task<ActionResult<RoomDTO>> Get(int room_ID)
        {
            try
            {
                var roomDTO = await _roomService.GetRoomById(room_ID);

                if (roomDTO == null)
                {
                    return NotFound();
                }

                return Ok(roomDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Room
        [HttpPost]
        public async Task<ActionResult<RoomDTO>> Create(RoomDTO newRoomDTO)
        {
            try
            {
                await _roomService.CreateRoom(newRoomDTO);

                return CreatedAtAction(nameof(Get), new { room_ID = newRoomDTO.Room_ID }, newRoomDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Room/{room_ID}
        [HttpPut("{room_ID}")]
        public async Task<IActionResult> Update(int room_ID, RoomDTO newRoomDTO)
        {
            try
            {
                var roomDTO = await _roomService.GetRoomById(room_ID);

                if (roomDTO == null)
                {
                    return NotFound();
                }

                await _roomService.UpdateRoom(newRoomDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Room/{room_ID}
        [HttpDelete("{room_ID}")]
        public async Task<IActionResult> Delete(int room_ID)
        {
            try
            {
                var roomDTO = await _roomService.GetRoomById(room_ID);

                if (roomDTO == null)
                {
                    return NotFound();
                }

                // Remove room
                await _roomService.DeleteRoom(room_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
