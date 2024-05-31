using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public ImageRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ImageDTO>> GetAllImages()
        {
            try
            {
                var imageDTOs = await _context.Images
                .Select(i => new ImageDTO
                {
                    Image_ID = i.Image_ID,
                    Image_Name = i.Image_Name,
                    Image_Address = i.Image_Address
                }).ToListAsync();

                return imageDTOs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<ImageDTO> GetImageById(int image_ID)
        {
            try
            {
                var imageDTO = await _context.Images
                .Where(i => i.Image_ID == image_ID)
                .Select(i => new ImageDTO
                {
                    Image_ID = i.Image_ID,
                    Image_Name = i.Image_Name,
                    Image_Address = i.Image_Address
                }).SingleOrDefaultAsync();

                return imageDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateImage(ImageDTO imageDTO)
        {
            try
            {
                var image = new Image();

                image.Image_Name = imageDTO.Image_Name;
                image.Image_Address = imageDTO.Image_Address;

                await _context.Images.AddAsync(image);
                await _context.SaveChangesAsync();

                imageDTO.Image_ID = image.Image_ID;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateImage(ImageDTO imageDTO)
        {
            try
            {
                var image = await _context.Images
                .Where(i => i.Image_ID == imageDTO.Image_ID).FirstOrDefaultAsync();

                if (image == null)
                {
                    throw new Exception("Not Found");
                }

                image.Image_Name = string.IsNullOrWhiteSpace(imageDTO.Image_Name) ? null : imageDTO.Image_Name;
                image.Image_Address = string.IsNullOrWhiteSpace(imageDTO.Image_Address) ? null : imageDTO.Image_Address;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteImage(int image_ID)
        {
            try
            {
                _context.Images.Remove(await _context.Images.FindAsync(image_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}