using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;
using SRW_Backend_API.Services.Services;

namespace SRW_Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatasetTypeController : ControllerBase
    {
        private readonly IDatasetTypeService _datasetTypeService;

        public DatasetTypeController(IDatasetTypeService datasetTypeService)
        {
            _datasetTypeService = datasetTypeService;
        }
        
        //GET: api/DatasetType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DatasetTypeDTO>>> GetAll()
        {
            try
            {
                var datasetTypeDTOs = await _datasetTypeService.GetAllDatasetTypes();

                return Ok(datasetTypeDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //GET: api/DatasetType/{datasetType_ID}
        [HttpGet("{datasetType_ID}")]
        public async Task<ActionResult<DatasetTypeDTO>> Get(int datasetType_ID)
        {
            try
            {
                var datasetTypeDTO = await _datasetTypeService.GetDatasetTypeById(datasetType_ID);
                return Ok(datasetTypeDTO);
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //POST: api/DatasetType
        [HttpPost]
        public async Task<ActionResult> Create(DatasetTypeDTO newdatasetTypeDTO)
        {
            try
            {
                await _datasetTypeService.CreateDatasetType(newdatasetTypeDTO);
                return CreatedAtAction(nameof(Get), new { datasetType_ID = newdatasetTypeDTO.DatasetType_ID }, newdatasetTypeDTO);
            }
            catch (Exception e) 
            { 
                return BadRequest(e.Message); 
            }
        }

        //PUT: api/DatasetType/{datasetType_ID}
        [HttpPut("{datasetType_ID}")]
        public async Task<ActionResult> Update(int datasetType_ID,DatasetTypeDTO newdatasetTypeDTO)
        {
            try
            {
                var datasetTypeDTO = await _datasetTypeService.GetDatasetTypeById(datasetType_ID);

                if(datasetTypeDTO == null)
                {
                    return NotFound();
                }

                await _datasetTypeService.UpdateDatasetType(newdatasetTypeDTO);
                return NoContent();
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //DELETE: api/DatasetType
        [HttpDelete("{datasetType_ID}")]
        public async Task<ActionResult> Delete(int datasetType_ID)
        {
            try
            {
                var datasetTypeDTO = await _datasetTypeService.GetDatasetTypeById(datasetType_ID);

                if (datasetTypeDTO == null)
                {
                    return NotFound();
                }

                await _datasetTypeService.DeleteDatasetType(datasetType_ID);
                return NoContent();
            }
            catch (Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
    }
}
