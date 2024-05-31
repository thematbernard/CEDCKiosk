using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Services.Interfaces
{ 
    public interface IImageService
    {
        Task<IEnumerable<ImageDTO>> GetAllImages();
        Task<ImageDTO> GetImageById(int image_ID);
        Task CreateImage(ImageDTO imageDTO);
        Task UpdateImage(ImageDTO imageDTO);
        Task DeleteImage(int image_ID);
    }
}
