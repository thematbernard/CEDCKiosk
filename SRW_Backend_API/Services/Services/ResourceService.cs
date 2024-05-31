using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task<IEnumerable<ResourceDTO>> GetAllResources()
        {
            try
            {
                return await _resourceRepository.GetAllResources();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResourceDTO> GetResourceById(int resource_ID)
        {
            try
            {
                return await _resourceRepository.GetResourceById(resource_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateResource(ResourceDTO resourceDTO)
        {
            try
            {
                await _resourceRepository.CreateResource(resourceDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateResource(ResourceDTO resourceDTO)
        {
            try
            {
                await _resourceRepository.UpdateResource(resourceDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteResource(int resource_ID)
        {
            try
            {
                await _resourceRepository.DeleteResource(resource_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteResourceByImage(int image_ID)
        {
            try
            {
                await _resourceRepository.DeleteResourceByImage(image_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteResourceByLocation(int location_ID)
        {
            try
            {
                await _resourceRepository.DeleteResourceByLocation(location_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
