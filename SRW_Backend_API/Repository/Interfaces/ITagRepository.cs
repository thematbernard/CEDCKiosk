using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<TagDTO>> GetAllTags();
        Task<TagDTO> GetTagById(int tag_ID);
        Task CreateTag(TagDTO tagDTO);
        Task UpdateTag(TagDTO tagDTO);
        Task DeleteTag(int tag_ID);
    }
}