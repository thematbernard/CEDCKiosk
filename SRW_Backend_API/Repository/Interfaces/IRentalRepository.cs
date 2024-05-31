using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface IRentalRepository
    {
        Task<IEnumerable<RentalDTO>> GetAllRentals();
        Task<RentalDTO> GetRentalById(int rental_ID);
        Task CreateRental(RentalDTO rentalDTO);
        Task UpdateRental(RentalDTO rentalDTO);
        Task DeleteRental(int rental_ID);
    }
}