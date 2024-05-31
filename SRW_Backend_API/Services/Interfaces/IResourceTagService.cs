﻿using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Services.Interfaces
{
    public interface IResourceTagService
    {
        Task<IEnumerable<ResourceTagDTO>> GetAllResourceTags();
        Task<ResourceTagDTO> GetResourceTagById(int resource_ID, int tag_ID);
        Task CreateResourceTag(ResourceTagDTO resourceTagDTO);
        Task DeleteResourceTag(int resource_ID, int tag_ID);
        Task DeleteResourceTagByResource(int resource_ID);
        Task DeleteResourceTagByTag(int tag_ID);
    }
}