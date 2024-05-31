using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class ResourceTagRepository : IResourceTagRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public ResourceTagRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResourceTagDTO>> GetAllResourceTags()
        {
            try
            {
                var resourceTagDTOs = await _context.ResourceTags
                .Include(rt => rt.Resource) // Include the related Resource
                .Include(rt => rt.Tag) // Include the related Tag
                .Select(rt => new ResourceTagDTO
                {
                    Resource_ID = rt.Resource_ID,
                    Tag_ID = rt.Tag_ID,
                  
                    Resource = rt.Resource != null
                        ? new ResourceDTO
                        {
                            Resource_ID = rt.Resource_ID,
                            Image_ID = rt.Resource.Image_ID,
                            Location_ID = rt.Resource.Location_ID,
                            Resource_Name = rt.Resource.Resource_Name,
                            Resource_Phone = rt.Resource.Resource_Phone,
                            Resource_Website = rt.Resource.Resource_Website,
                            Resource_Eligibility = rt.Resource.Resource_Eligibility,
                            Resource_Description = rt.Resource.Resource_Description,

                            Location = rt.Resource.Location != null
                                ? new LocationDTO
                                {
                                    Location_ID = rt.Resource.Location.Location_ID,
                                    Location_Name = rt.Resource.Location.Location_Name,
                                    Location_Street = rt.Resource.Location.Location_Street,
                                    Location_City = rt.Resource.Location.Location_City,
                                    Location_County = rt.Resource.Location.Location_County,
                                    Location_State = rt.Resource.Location.Location_State,
                                    Location_Country = rt.Resource.Location.Location_Country,
                                    Location_Zip = rt.Resource.Location.Location_Zip
                                }
                                : null,

                            Image = rt.Resource.Image != null
                                ? new ImageDTO
                                {
                                    Image_ID = rt.Resource.Image.Image_ID,
                                    Image_Name = rt.Resource.Image.Image_Name,
                                    Image_Address = rt.Resource.Image.Image_Address
                                }
                                : null
                        }
                        : null,

                    Tag = rt.Tag != null
                        ? new TagDTO
                        {
                            Tag_ID = rt.Tag.Tag_ID,
                            Tag_Name = rt.Tag.Tag_Name
                        }
                        : null
                }).ToListAsync();

                return resourceTagDTOs;
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
                var resourceTagDTO = await _context.ResourceTags
                .Include(rt => rt.Resource) // Include the related Resource
                .Include(rt => rt.Tag) // Include the related Tag
                .Where(rt => rt.Resource_ID == resource_ID && rt.Tag_ID == tag_ID)
                .Select(rt => new ResourceTagDTO
                {
                    Resource_ID = rt.Resource_ID,
                    Tag_ID = rt.Tag_ID,

                    Resource = rt.Resource != null
                        ? new ResourceDTO
                        {
                            Resource_ID = rt.Resource_ID,
                            Image_ID = rt.Resource.Image_ID,
                            Location_ID = rt.Resource.Location_ID,
                            Resource_Name = rt.Resource.Resource_Name,
                            Resource_Phone = rt.Resource.Resource_Phone,
                            Resource_Website = rt.Resource.Resource_Website,
                            Resource_Eligibility = rt.Resource.Resource_Eligibility,
                            Resource_Description = rt.Resource.Resource_Description,

                            Location = rt.Resource.Location != null
                                ? new LocationDTO
                                {
                                    Location_ID = rt.Resource.Location.Location_ID,
                                    Location_Name = rt.Resource.Location.Location_Name,
                                    Location_Street = rt.Resource.Location.Location_Street,
                                    Location_City = rt.Resource.Location.Location_City,
                                    Location_County = rt.Resource.Location.Location_County,
                                    Location_State = rt.Resource.Location.Location_State,
                                    Location_Country = rt.Resource.Location.Location_Country,
                                    Location_Zip = rt.Resource.Location.Location_Zip
                                }
                                : null,

                            Image = rt.Resource.Image != null
                                ? new ImageDTO
                                {
                                    Image_ID = rt.Resource.Image.Image_ID,
                                    Image_Name = rt.Resource.Image.Image_Name,
                                    Image_Address = rt.Resource.Image.Image_Address
                                }
                                : null
                        }
                        : null,

                    Tag = rt.Tag != null
                        ? new TagDTO
                        {
                            Tag_ID = rt.Tag.Tag_ID,
                            Tag_Name = rt.Tag.Tag_Name
                        }
                        : null
                }).SingleOrDefaultAsync();

                return resourceTagDTO;
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
                var resourceTag = new ResourceTag();

                resourceTag.Resource = await _context.Resources.FindAsync(resourceTagDTO.Resource_ID);
                resourceTag.Tag = await _context.Tags.FindAsync(resourceTagDTO.Tag_ID);

                await _context.ResourceTags.AddAsync(resourceTag);
                await _context.SaveChangesAsync();
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
                _context.ResourceTags.Remove(await _context.ResourceTags.FindAsync(resource_ID, tag_ID));
                await _context.SaveChangesAsync();
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
                // Find the ResourceTag entries associated with the given resource ID
                var resourceTags = await _context.ResourceTags
                    .Where(rt => rt.Resource_ID == resource_ID)
                    .ToListAsync();

                // Remove the associations (remove the ResourceTag entries)
                _context.ResourceTags.RemoveRange(resourceTags);

                // Save changes to the database
                await _context.SaveChangesAsync();
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
                // Find the ResourceTag entries associated with the given tag ID
                var resourceTags = await _context.ResourceTags
                    .Where(rt => rt.Tag_ID == tag_ID)
                    .ToListAsync();

                // Remove the associations (remove the ResourceTag entries)
                _context.ResourceTags.RemoveRange(resourceTags);

                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}