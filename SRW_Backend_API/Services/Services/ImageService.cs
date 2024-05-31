using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<IEnumerable<ImageDTO>> GetAllImages()
        {
            try
            {
                return await _imageRepository.GetAllImages();
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
                return await _imageRepository.GetImageById(image_ID);
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
                await _imageRepository.CreateImage(imageDTO);
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
                await _imageRepository.UpdateImage(imageDTO);
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
                await _imageRepository.DeleteImage(image_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
