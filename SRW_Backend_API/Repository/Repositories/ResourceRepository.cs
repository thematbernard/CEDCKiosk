using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly SRWVirtualHubDbContext _context;
        private readonly IResourceTagService _resourceTagService;

        public ResourceRepository(SRWVirtualHubDbContext context, IResourceTagService resourceTagService)
        {
            _context = context;
            _resourceTagService = resourceTagService;
        }

        public async Task<IEnumerable<ResourceDTO>> GetAllResources()
        {
            try
            {
                var resourceDTOs = await _context.Resources
                .Include(r => r.Image) // Include the related Image
                .Include(r => r.Location) // Include the related Location 
                .Select(r => new ResourceDTO
                {
                    Resource_ID = r.Resource_ID,
                    Image_ID = r.Image_ID,
                    Location_ID = r.Location_ID,
                    Resource_Name = r.Resource_Name,
                    Resource_Phone = r.Resource_Phone,
                    Resource_Website = r.Resource_Website,
                    Resource_Eligibility = r.Resource_Eligibility,
                    Resource_Description = r.Resource_Description,

                    Location = r.Location != null
                        ? new LocationDTO
                        {
                            Location_ID = r.Location.Location_ID,
                            Location_Name = r.Location.Location_Name,
                            Location_Street = r.Location.Location_Street,
                            Location_City = r.Location.Location_City,
                            Location_County = r.Location.Location_County,
                            Location_State = r.Location.Location_State,
                            Location_Country = r.Location.Location_Country,
                            Location_Zip = r.Location.Location_Zip
                        }
                        : null,

                    Image = r.Image != null
                        ? new ImageDTO
                        {
                            Image_ID = r.Image.Image_ID,
                            Image_Name = r.Image.Image_Name,
                            Image_Address = r.Image.Image_Address
                        }
                        : null
                }).ToListAsync();

                return resourceDTOs;
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
                var resourceDTO = await _context.Resources
                .Include(r => r.Image) // Include the related Image
                .Include(r => r.Location) // Include the related Location
                .Where(r => r.Resource_ID == resource_ID)
                .Select(r => new ResourceDTO
                {
                    Resource_ID = r.Resource_ID,
                    Image_ID = r.Image_ID,
                    Location_ID = r.Location_ID,
                    Resource_Name = r.Resource_Name,
                    Resource_Phone = r.Resource_Phone,
                    Resource_Website = r.Resource_Website,
                    Resource_Eligibility = r.Resource_Eligibility,
                    Resource_Description = r.Resource_Description,

                    Location = r.Location != null
                        ? new LocationDTO
                        {
                            Location_ID = r.Location.Location_ID,
                            Location_Name = r.Location.Location_Name,
                            Location_Street = r.Location.Location_Street,
                            Location_City = r.Location.Location_City,
                            Location_County = r.Location.Location_County,
                            Location_State = r.Location.Location_State,
                            Location_Country = r.Location.Location_Country,
                            Location_Zip = r.Location.Location_Zip
                        }
                        : null,

                    Image = r.Image != null
                        ? new ImageDTO
                        {
                            Image_ID = r.Image.Image_ID,
                            Image_Name = r.Image.Image_Name,
                            Image_Address = r.Image.Image_Address
                        }
                        : null
                }).SingleOrDefaultAsync();
                
                return resourceDTO;
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
                var resource = new Resource();

                resource.Image = await _context.Images.FindAsync(resourceDTO.Image_ID);
                resource.Location = await _context.Locations.FindAsync(resourceDTO.Location_ID);
                resource.Resource_Name = resourceDTO.Resource_Name;
                resource.Resource_Phone = resourceDTO.Resource_Phone;
                resource.Resource_Website = resourceDTO.Resource_Website;
                resource.Resource_Eligibility = resourceDTO.Resource_Eligibility;
                resource.Resource_Description = resourceDTO.Resource_Description;

                await _context.Resources.AddAsync(resource);
                await _context.SaveChangesAsync();

                resourceDTO.Resource_ID = resource.Resource_ID;
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
                var resource = await _context.Resources
                .Include(r => r.Image)
                .Include(r => r.Location)
                .Where(r => r.Resource_ID == resourceDTO.Resource_ID).FirstOrDefaultAsync();

                if (resource == null)
                {
                    throw new Exception("Not Found");
                }

                if (resource.Image.Image_ID != resourceDTO.Image_ID)
                {
                    resource.Image = await _context.Images.FindAsync(resourceDTO.Image_ID);
                }
                if (resource.Location.Location_ID != resourceDTO.Location_ID)
                {
                    resource.Location = await _context.Locations.FindAsync(resourceDTO.Location_ID);
                }

                resource.Resource_Name = resourceDTO.Resource_Name;
                resource.Resource_Phone = string.IsNullOrWhiteSpace(resourceDTO.Resource_Phone) ? null : resourceDTO.Resource_Phone;
                resource.Resource_Website = string.IsNullOrWhiteSpace(resourceDTO.Resource_Website) ? null : resourceDTO.Resource_Website;
                resource.Resource_Eligibility = string.IsNullOrWhiteSpace(resourceDTO.Resource_Eligibility) ? null : resourceDTO.Resource_Eligibility;
                resource.Resource_Description = string.IsNullOrWhiteSpace(resourceDTO.Resource_Description) ? null : resourceDTO.Resource_Description;

                await _context.SaveChangesAsync();
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
                _context.Resources.Remove(await _context.Resources.FindAsync(resource_ID));
                await _context.SaveChangesAsync();
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
                // Find the Resource entries associated with the given image ID
                var resources = await _context.Resources
                    .Where(r => r.Image_ID == image_ID)
                    .ToListAsync();

                foreach (var resource in resources)
                {
                    // Remove associated resourceTags first
                    await _resourceTagService.DeleteResourceTagByResource(resource.Resource_ID);
                }

                // Remove the associations (remove the Resource entries)
                _context.Resources.RemoveRange(resources);

                // Save changes to the database
                await _context.SaveChangesAsync();
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
                // Find the Resource entries associated with the given location ID
                var resources = await _context.Resources
                    .Where(r => r.Location_ID == location_ID)
                    .ToListAsync();

                foreach (var resource in resources)
                {
                    // Remove associated resourceTags first
                    await _resourceTagService.DeleteResourceTagByResource(resource.Resource_ID);
                }

                // Remove the associations (remove the Resource entries)
                _context.Resources.RemoveRange(resources);

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