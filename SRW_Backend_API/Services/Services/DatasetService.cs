using SRW_Backend_API.Repository;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class DatasetService : IDatasetService
    {
        private readonly IDatasetRepository _datasetRepository;

        public DatasetService(IDatasetRepository repository)
        {
            _datasetRepository = repository;
        }

        public async Task<IEnumerable<DatasetDTO>> GetAllDatasets()
        {
            try
            {
                return await _datasetRepository.GetAllDatasets();
            }
            catch
            {
                throw;
            }
        }

        public async Task<DatasetDTO> GetDatasetById(int dataset_ID)
        {
            try
            {
                return await _datasetRepository.GetDatasetById(dataset_ID);
            }
            catch 
            { 
                throw; 
            }
        }

        public async Task CreateDataset(DatasetDTO datasetDTO)
        {
            try
            {
                await _datasetRepository.CreateDataset(datasetDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateDataset(DatasetDTO datasetDTO)
        {
            try
            {
                await _datasetRepository.UpdateDataset(datasetDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteDataset(int dataset_ID)
        {
            try
            {
                await _datasetRepository.DeleteDataset(dataset_ID);
            }
            catch
            {
                throw;
            }
        }

    }
}
