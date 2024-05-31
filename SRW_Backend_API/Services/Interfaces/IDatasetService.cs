using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Services.Interfaces
{
    public interface IDatasetService
    {
        Task<IEnumerable<DatasetDTO>> GetAllDatasets();
        Task<DatasetDTO> GetDatasetById(int dataset_ID);
        Task CreateDataset(DatasetDTO datasetDTO);
        Task UpdateDataset(DatasetDTO datasetDTO);
        Task DeleteDataset(int dataset_ID);
    }
}
