using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public TagRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TagDTO>> GetAllTags()
        {
            try
            {
                var tagDTOs = await _context.Tags
                .Select(t => new TagDTO
                {
                    Tag_ID = t.Tag_ID,
                    Tag_Name= t.Tag_Name
                }).ToListAsync();

                return tagDTOs;

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
                var tagDTO = await _context.Tags
                .Where(t => t.Tag_ID == tag_ID)
                .Select(t => new TagDTO
                {
                    Tag_ID = t.Tag_ID,
                    Tag_Name = t.Tag_Name
                }).SingleOrDefaultAsync();

                return tagDTO;
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
                var tag = new Tag();

                tag.Tag_Name = tagDTO.Tag_Name;

                await _context.Tags.AddAsync(tag);
                await _context.SaveChangesAsync();

                tagDTO.Tag_ID = tag.Tag_ID;
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
                var tag = await _context.Tags
                .Where(t => t.Tag_ID == tagDTO.Tag_ID).FirstOrDefaultAsync();

                if (tag == null)
                {
                    throw new Exception("Not Found");
                }
 
                tag.Tag_Name = string.IsNullOrWhiteSpace(tagDTO.Tag_Name) ? null : tagDTO.Tag_Name;

                await _context.SaveChangesAsync();
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
                _context.Tags.Remove(await _context.Tags.FindAsync(tag_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}