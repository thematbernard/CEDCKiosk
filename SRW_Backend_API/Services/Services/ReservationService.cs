using SRW_Backend_API.DTOs;
using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IEnumerable<ReservationDTO>> GetAllReservations()
        {
            try
            {
                return await _reservationRepository.GetAllReservations();
            }
            catch
            {
                throw;
            }
        }

        public async Task<ReservationDTO> GetReservationById(int reservation_ID)
        {
            try
            {
                return await _reservationRepository.GetReservationById(reservation_ID);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateReservation(ReservationDTO reservationDTO)
        {
            try
            {
                await _reservationRepository.CreateReservation(reservationDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateReservation(ReservationDTO reservationDTO)
        {
            try
            {
                await _reservationRepository.UpdateReservation(reservationDTO);
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteReservation(int reservation_ID)
        {
            try
            {
                await _reservationRepository.DeleteReservation(reservation_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
