using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<TagDTO>> GetAllTags()
        {
            try
            {
                return await _tagRepository.GetAllTags();
            }
            catch
            {
                throw;
            }
        }

        public async Task<TagDTO> GetTagById(int tag_ID)
        {
            try
            {
                return await _tagRepository.GetTagById(tag_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateTag(TagDTO tagDTO)
        {
            try
            {
                await _tagRepository.CreateTag(tagDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateTag(TagDTO tagDTO)
        {
            try
            {
                await _tagRepository.UpdateTag(tagDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteTag(int tag_ID)
        {
            try
            {
                await _tagRepository.DeleteTag(tag_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}


