using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{

    public interface IResourceRepository
    {
        Task<IEnumerable<ResourceDTO>> GetAllResources();
        Task<ResourceDTO> GetResourceById(int resource_ID);
        Task CreateResource(ResourceDTO resourceDTO);
        Task UpdateResource(ResourceDTO resourceDTO);
        Task DeleteResource(int resource_ID);
        Task DeleteResourceByImage(int image_ID);
        Task DeleteResourceByLocation(int location_ID);
    }
}