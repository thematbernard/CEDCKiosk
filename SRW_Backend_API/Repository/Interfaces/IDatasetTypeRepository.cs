using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface IDatasetTypeRepository
    {
        Task<IEnumerable<DatasetTypeDTO>> GetAllDatasetTypes();
        Task<DatasetTypeDTO> GetDatasetTypeByName(string datasetTypeName);
        Task<DatasetTypeDTO> GetDatasetTypeById(int datasetType_ID);
        Task CreateDatasetType(DatasetTypeDTO datasetTypeDTO);
        Task UpdateDatasetType(DatasetTypeDTO datasetTypeDTO);
        Task DeleteDatasetType(int datasetType_ID);
    }
}
