using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<IEnumerable<RentalDTO>> GetAllRentals()
        {
            try
            {
                return await _rentalRepository.GetAllRentals();
            }
            catch
            {
                throw;
            }
        }

        public async Task<RentalDTO> GetRentalById(int rental_ID)
        {
            try
            {
                return await _rentalRepository.GetRentalById(rental_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateRental(RentalDTO rentalDTO)
        {
            try
            {
                await _rentalRepository.CreateRental(rentalDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateRental(RentalDTO rentalDTO)
        {
            try
            {
                await _rentalRepository.UpdateRental(rentalDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteRental(int rental_ID)
        {
            try
            {
                await _rentalRepository.DeleteRental(rental_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
