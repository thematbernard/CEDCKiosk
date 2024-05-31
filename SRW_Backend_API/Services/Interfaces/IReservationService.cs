using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Services.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDTO>> GetAllReservations();
        Task<ReservationDTO> GetReservationById(int reservation_ID);
        Task CreateReservation(ReservationDTO reservationDTO);
        Task UpdateReservation(ReservationDTO reservationDTO);
        Task DeleteReservation(int reservation_ID);
    }
}