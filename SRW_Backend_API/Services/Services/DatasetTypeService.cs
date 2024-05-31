using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class DatasetTypeService: IDatasetTypeService
    {
        private readonly IDatasetTypeRepository _datasetTyperepository;

        public DatasetTypeService(IDatasetTypeRepository datasetTyperepository)
        {
            _datasetTyperepository = datasetTyperepository;
        }

        public async Task<IEnumerable<DatasetTypeDTO>> GetAllDatasetTypes()
        {
            try
            {
                return await _datasetTyperepository.GetAllDatasetTypes();
            }
            catch
            {
                throw;
            }
        }

        public async Task<DatasetTypeDTO> GetDatasetTypeByName(string datasetTypeName)
        {
            try
            {
                return await _datasetTyperepository.GetDatasetTypeByName(datasetTypeName);
            }
            catch 
            { 
                throw;
            }
        }

        public async Task CreateDatasetType(DatasetTypeDTO datasetTypeDTO)
        {
            try
            {
                await _datasetTyperepository.CreateDatasetType(datasetTypeDTO);
            }
            catch 
            { 
                throw;
            }
        }

        public async Task<DatasetTypeDTO> GetDatasetTypeById(int datasetType_ID)
        {
            try
            {
                return await _datasetTyperepository.GetDatasetTypeById(datasetType_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateDatasetType(DatasetTypeDTO datasetTypeDTO)
        {
            try
            {
                await _datasetTyperepository.UpdateDatasetType(datasetTypeDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteDatasetType(int datasetType_ID)
        {
            try
            {
                await _datasetTyperepository.DeleteDatasetType(datasetType_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
