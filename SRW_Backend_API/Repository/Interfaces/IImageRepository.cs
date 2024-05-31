using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface IImageRepository
    {
        Task<IEnumerable<ImageDTO>> GetAllImages();
        Task<ImageDTO> GetImageById(int image_ID);
        Task CreateImage(ImageDTO imageDTO);
        Task UpdateImage(ImageDTO imageDTO);
        Task DeleteImage(int image_ID);
    }
}