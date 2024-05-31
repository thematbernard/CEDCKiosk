using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly IEquipmentService _equipmentService;

        public EquipmentController(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        // GET: api/Equipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipmentDTO>>> GetAll()
        {
            try
            {
                var equipmentDTOs = await _equipmentService.GetAllEquipment();

                return Ok(equipmentDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Equipment/{equipment_ID}
        [HttpGet("{equipment_ID}")]
        public async Task<ActionResult<EquipmentDTO>> Get(int equipment_ID)
        {
            try
            {
                var equipmentDTO = await _equipmentService.GetEquipmentById(equipment_ID);

                if (equipmentDTO == null)
                {
                    return NotFound();
                }

                return Ok(equipmentDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/Equipment
        [HttpPost]
        public async Task<ActionResult<EquipmentDTO>> Create(EquipmentDTO newEquipmentDTO)
        {
            try
            {
                await _equipmentService.CreateEquipment(newEquipmentDTO);

                return CreatedAtAction(nameof(Get), new { equipment_ID = newEquipmentDTO.Equipment_ID }, newEquipmentDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Equipment/{equipment_ID}
        [HttpPut("{equipment_ID}")]
        public async Task<IActionResult> Update(int equipment_ID, EquipmentDTO newEquipmentDTO)
        {
            try
            {
                var equipmentDTO = await _equipmentService.GetEquipmentById(equipment_ID);

                if (equipmentDTO == null)
                {
                    return NotFound();
                }

                await _equipmentService.UpdateEquipment(newEquipmentDTO);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Equipment/{equipment_ID}
        [HttpDelete("{equipment_ID}")]
        public async Task<IActionResult> Delete(int equipment_ID)
        {
            try
            {
                var equipmentDTO = await _equipmentService.GetEquipmentById(equipment_ID);

                if (equipmentDTO == null)
                {
                    return NotFound();
                }

                // Remove equipment
                await _equipmentService.DeleteEquipment(equipment_ID);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}