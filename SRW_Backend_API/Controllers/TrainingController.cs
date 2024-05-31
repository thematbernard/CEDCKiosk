using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;
using SRW_Backend_API.Services.Services;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        // GET: api/Training
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrainingDTO>>> GetAll()
        {
            try
            {
                var trainingDTOs = await _trainingService.GetAllTraining();

                return Ok(trainingDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Training/{training_ID}
        [HttpGet("{training_ID}")]
        public async Task<ActionResult<TrainingDTO>> Get(int training_ID)
        {
            try
            {
                var trainingDTO = await _trainingService.GetTrainingById(training_ID);

                if (trainingDTO == null)
                {
                    return NotFound();
                }

                return Ok(trainingDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Training
        [HttpPost]
        public async Task<ActionResult<TrainingDTO>> Create(TrainingDTO newTrainingDTO)
        {
            try
            {
                await _trainingService.CreateTraining(newTrainingDTO);

                return CreatedAtAction(nameof(Get), new { training_ID = newTrainingDTO.Training_ID }, newTrainingDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Training/{training_ID}
        [HttpPut("{training_ID}")]
        public async Task<IActionResult> Update(int training_ID, TrainingDTO newTrainingDTO)
        {
            try
            {
                var trainingDTO = await _trainingService.GetTrainingById(training_ID);

                if (trainingDTO == null)
                {
                    return NotFound();
                }

                await _trainingService.UpdateTraining(newTrainingDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Training/{training_ID}
        [HttpDelete("{training_ID}")]
        public async Task<IActionResult> Delete(int training_ID)
        {
            try
            {
                var trainingDTO = await _trainingService.GetTrainingById(training_ID);

                if (trainingDTO == null)
                {
                    return NotFound();
                }

                // Remove training
                await _trainingService.DeleteTraining(training_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
