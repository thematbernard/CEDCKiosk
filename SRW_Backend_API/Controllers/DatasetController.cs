using Microsoft.AspNetCore.Mvc;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;
using SRW_Backend_API.Services.Services;

namespace SRW_Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatasetController : ControllerBase
    {
        private readonly IDatasetService _datasetService;

        public DatasetController(IDatasetService datasetService)
        {
            _datasetService = datasetService;
        }
        // GET : api/Dataset
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DatasetDTO>>> GetAll()
        {
            try
            {
                var datasetDTOs = await _datasetService.GetAllDatasets();

                return Ok(datasetDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{dataset_ID}")]
        public async Task<ActionResult<DatasetDTO>> Get(int dataset_ID)
        {
            try
            {
                var datasetDTO = await _datasetService.GetDatasetById(dataset_ID);
                if (datasetDTO == null)
                {
                    return NotFound();
                }
                return Ok(datasetDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //POST: api/Dataset
        [HttpPost]
        public async Task<ActionResult<DatasetDTO>> Create(DatasetDTO newdatasetDTO)
        {
            try
            {
                await _datasetService.CreateDataset(newdatasetDTO);
                return CreatedAtAction(nameof(Get), new { dataset_ID = newdatasetDTO.Dataset_ID }, newdatasetDTO);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //PUT : api/Dataset/{dataset_ID}
        [HttpPut("{dataset_ID}")]
        public async Task<IActionResult> Update(int dataset_ID, DatasetDTO newdatasetDTO)
        {
            try
            {
                var datasetDTO = await _datasetService.GetDatasetById(dataset_ID);
                if(datasetDTO == null)
                {
                    return NotFound();
                }

                await _datasetService.UpdateDataset(newdatasetDTO);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //DELETE : api/Dataset/{dataset_ID}
        [HttpDelete("{dataset_ID}")]
        public async Task<IActionResult> Delete(int dataset_ID)
        {
            try
            {
                var datasetDTO = await _datasetService.GetDatasetById(dataset_ID);
                if(datasetDTO == null)
                {
                    return NotFound();
                }

                await _datasetService.DeleteDataset(dataset_ID);
                return NoContent();
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
