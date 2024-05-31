using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FunctionController : ControllerBase
    {
        private readonly IFunctionService _functionService;

        public FunctionController(IFunctionService functionService)
        {
            _functionService = functionService;
        }

        // GET: api/Function
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FunctionDTO>>> GetAll()
        {
            try
            {
                var functionDTOs = await _functionService.GetAllFunctions();

                return Ok(functionDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Function/{function_ID}
        [HttpGet("{function_ID}")]
        public async Task<ActionResult<FunctionDTO>> Get(int function_ID)
        {
            try
            {
                var functionDTO = await _functionService.GetFunctionById(function_ID);

                if (functionDTO == null)
                {
                    return NotFound();
                }

                return Ok(functionDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Function
        [HttpPost]
        public async Task<ActionResult<FunctionDTO>> Create(FunctionDTO newFunctionDTO)
        {
            try
            {
                await _functionService.CreateFunction(newFunctionDTO);

                return CreatedAtAction(nameof(Get), new { function_ID = newFunctionDTO.Function_ID }, newFunctionDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Function/{function_ID}
        [HttpPut("{function_ID}")]
        public async Task<IActionResult> Update(int function_ID, FunctionDTO newFunctionDTO)
        {
            try
            {
                var functionDTO = await _functionService.GetFunctionById(function_ID);

                if (functionDTO == null)
                {
                    return NotFound();
                }

                await _functionService.UpdateFunction(newFunctionDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Function/{function_ID}
        [HttpDelete("{function_ID}")]
        public async Task<IActionResult> Delete(int function_ID)
        {
            try
            {
                var functionDTO = await _functionService.GetFunctionById(function_ID);

                if (functionDTO == null)
                {
                    return NotFound();
                }

                // Remove function
                await _functionService.DeleteFunction(function_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
