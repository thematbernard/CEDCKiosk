using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface IDatasetRepository
    {
        Task<IEnumerable<DatasetDTO>> GetAllDatasets();
        Task<DatasetDTO> GetDatasetById(int dataset_ID);
        Task CreateDataset(DatasetDTO datasetDTO);
        Task UpdateDataset(DatasetDTO datasetDTO);
        Task DeleteDataset(int dataset_ID);
    }
}
