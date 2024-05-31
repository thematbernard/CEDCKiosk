using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public ReservationRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ReservationDTO>> GetAllReservations()
        {
            try
            {
                var reservationDTOs = await _context.Reservations
                    .Include(r => r.User)
                    .Include(r => r.Room)
                    .Select(r => new ReservationDTO
                    {
                        Reservation_ID = r.Reservation_ID,
                        User_ID = r.User_ID,
                        Room_ID = r.Room_ID,
                        Reservation_Start_Date = r.Reservation_Start_Date,
                        Reservation_End_Date = r.Reservation_End_Date,
                        Reservation_Notification = r.Reservation_Notification,

                        User = r.User != null
                            ? new UserDTO
                            {
                                User_ID = r.User.User_ID,
                                User_First_Name = r.User.User_First_Name,
                                User_Last_Name = r.User.User_Last_Name,
                                User_Phone = r.User.User_Phone,
                                User_Email = r.User.User_Email,
                                User_Password = r.User.User_Password
                            }
                            : null,

                        Room = r.Room != null
                            ? new RoomDTO
                            {
                                Room_ID = r.Room.Room_ID,
                                RoomType_ID = r.Room.RoomType_ID,
                                Image_ID = r.Room.Image_ID,
                                Room_Name = r.Room.Room_Name,
                                Room_Number = r.Room.Room_Number,
                                Room_Floor = r.Room.Room_Floor,
                                Room_Description = r.Room.Room_Description
                            }
                            : null
                    }).ToListAsync();

                return reservationDTOs;
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
                var reservationDTO = await _context.Reservations
                    .Include(r => r.User)
                    .Include(r => r.Room)
                    .Where(r => r.Reservation_ID == reservation_ID)
                    .Select(r => new ReservationDTO
                    {
                        Reservation_ID = r.Reservation_ID,
                        User_ID = r.User_ID,
                        Room_ID = r.Room_ID,
                        Reservation_Start_Date = r.Reservation_Start_Date,
                        Reservation_End_Date = r.Reservation_End_Date,
                        Reservation_Notification = r.Reservation_Notification,

                        User = r.User != null
                            ? new UserDTO
                            {
                                User_ID = r.User.User_ID,
                                User_First_Name = r.User.User_First_Name,
                                User_Last_Name = r.User.User_Last_Name,
                                User_Phone = r.User.User_Phone,
                                User_Email = r.User.User_Email,
                                User_Password = r.User.User_Password
                            }
                            : null,

                        Room = r.Room != null
                            ? new RoomDTO
                            {
                                Room_ID = r.Room.Room_ID,
                                RoomType_ID = r.Room.RoomType_ID,
                                Image_ID = r.Room.Image_ID,
                                Room_Name = r.Room.Room_Name,
                                Room_Number = r.Room.Room_Number,
                                Room_Floor = r.Room.Room_Floor,
                                Room_Description = r.Room.Room_Description
                            }
                            : null
                    }).SingleOrDefaultAsync();

                return reservationDTO;
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
                var reservation = new Reservation();

                reservation.User = await _context.Users.FindAsync(reservationDTO.User_ID);
                reservation.Room = await _context.Rooms.FindAsync(reservationDTO.Room_ID);
                reservation.Reservation_Start_Date = reservationDTO.Reservation_Start_Date;
                reservation.Reservation_End_Date = reservationDTO.Reservation_End_Date;
                reservation.Reservation_Notification = reservationDTO.Reservation_Notification;

                await _context.Reservations.AddAsync(reservation);
                await _context.SaveChangesAsync();

                reservationDTO.Reservation_ID = reservation.Reservation_ID;
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
                var reservation = await _context.Reservations
                    .Include(r => r.User)
                    .Include(r => r.Room)
                    .Where(r => r.Reservation_ID == reservationDTO.Reservation_ID)
                    .FirstOrDefaultAsync();

                if (reservation == null)
                {
                    throw new Exception("Not Found");
                }

                if (reservation.User.User_ID != reservationDTO.User_ID)
                {
                    reservation.User = await _context.Users.FindAsync(reservationDTO.User_ID);
                }
                if (reservation.Room.Room_ID != reservationDTO.Room_ID)
                {
                    reservation.Room = await _context.Rooms.FindAsync(reservationDTO.Room_ID);
                }

                reservation.Reservation_Start_Date = reservationDTO.Reservation_Start_Date;
                reservation.Reservation_End_Date = reservationDTO.Reservation_End_Date;
                reservation.Reservation_Notification = reservationDTO.Reservation_Notification;

                await _context.SaveChangesAsync();
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
                _context.Reservations.Remove(await _context.Reservations.FindAsync(reservation_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
