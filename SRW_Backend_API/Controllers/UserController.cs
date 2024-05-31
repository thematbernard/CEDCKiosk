using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            try
            {
                var userDTOs = await _userService.GetAllUsers();

                return Ok(userDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/User/{user_ID}
        [HttpGet("{user_ID}")]
        public async Task<ActionResult<UserDTO>> Get(int user_ID)
        {
            try
            {
                var userDTO = await _userService.GetUserById(user_ID);

                if (userDTO == null)
                {
                    return NotFound();
                }

                return Ok(userDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Create(UserDTO newUserDTO)
        {
            try
            {
                await _userService.CreateUser(newUserDTO);

                return CreatedAtAction(nameof(Get), new { user_ID = newUserDTO.User_ID }, newUserDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/User/{user_ID}
        [HttpPut("{user_ID}")]
        public async Task<IActionResult> Update(int user_ID, UserDTO newUserDTO)
        {
            try
            {
                var userDTO = await _userService.GetUserById(user_ID);

                if (userDTO == null)
                {
                    return NotFound();
                }

                await _userService.UpdateUser(newUserDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/User/{user_ID}
        [HttpDelete("{user_ID}")]
        public async Task<IActionResult> Delete(int user_ID)
        {
            try
            {
                var userDTO = await _userService.GetUserById(user_ID);

                if (userDTO == null)
                {
                    return NotFound();
                }

                // Remove user
                await _userService.DeleteUser(user_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
