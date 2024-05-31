using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class ResourceTagService : IResourceTagService
    {
        private readonly IResourceTagRepository _resourceTagRepository;

        public ResourceTagService(IResourceTagRepository resourceTagRepository)
        {
            _resourceTagRepository = resourceTagRepository;
        }

        public async Task<IEnumerable<ResourceTagDTO>> GetAllResourceTags()
        {
            try
            {
                return await _resourceTagRepository.GetAllResourceTags();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResourceTagDTO> GetResourceTagById(int resource_ID, int tag_ID)
        {
            try
            {
                return await _resourceTagRepository.GetResourceTagById(resource_ID, tag_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateResourceTag(ResourceTagDTO resourceTagDTO)
        {
            try
            {
                await _resourceTagRepository.CreateResourceTag(resourceTagDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteResourceTag(int resource_ID, int tag_ID)
        {
            try
            {
                await _resourceTagRepository.DeleteResourceTag(resource_ID, tag_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteResourceTagByResource(int resource_ID)
        {
            try
            {
                await _resourceTagRepository.DeleteResourceTagByResource(resource_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteResourceTagByTag(int tag_ID)
        {
            try
            {
                await _resourceTagRepository.DeleteResourceTagByTag(tag_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}