using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserRoomController : ControllerBase
    {
        private readonly IUserRoomService _userRoomService;

        public UserRoomController(IUserRoomService userRoomService)
        {
            _userRoomService = userRoomService;
        }

        // GET: api/UserRoom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoomDTO>>> GetAll()
        {
            try
            {
                var userRoomDTOs = await _userRoomService.GetAllUserRooms();

                return Ok(userRoomDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/UserRoom/{user_ID}/{room_ID}
        [HttpGet("{user_ID}/{room_ID}")]
        public async Task<ActionResult<UserRoomDTO>> Get(int user_ID, int room_ID)
        {
            try
            {
                var userRoomDTO = await _userRoomService.GetUserRoomById(user_ID, room_ID);

                if (userRoomDTO == null)
                {
                    return NotFound();
                }

                return Ok(userRoomDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/UserRoom
        [HttpPost]
        public async Task<ActionResult<UserRoomDTO>> Create(UserRoomDTO newUserRoomDTO)
        {
            try
            {
                await _userRoomService.CreateUserRoom(newUserRoomDTO);

                return CreatedAtAction(nameof(Get), new { user_ID = newUserRoomDTO.User_ID, room_ID = newUserRoomDTO.Room_ID }, newUserRoomDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/UserRoom/{user_ID}/{room_ID}
        [HttpDelete("{user_ID}/{room_ID}")]
        public async Task<IActionResult> Delete(int user_ID, int room_ID)
        {
            try
            {
                var userRoomDTO = await _userRoomService.GetUserRoomById(user_ID, room_ID);

                if (userRoomDTO == null)
                {
                    return NotFound();
                }

                await _userRoomService.DeleteUserRoom(user_ID, room_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
