using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public RentalRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RentalDTO>> GetAllRentals()
        {
            try
            {
                var rentalDTOs = await _context.Rentals
                    .Include(r => r.User)
                    .Include(r => r.Equipment)
                    .Select(r => new RentalDTO
                    {
                        Rental_ID = r.Rental_ID,
                        User_ID = r.User_ID,
                        Equipment_ID = r.Equipment_ID,
                        Rental_Start_Date = r.Rental_Start_Date,
                        Rental_End_Date = r.Rental_End_Date,
                        Rental_Approved = r.Rental_Approved,
                        Rental_Returned = r.Rental_Returned,

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

                        Equipment = r.Equipment != null
                            ? new EquipmentDTO
                            {
                                Equipment_ID = r.Equipment.Equipment_ID,
                                Image_ID = r.Equipment.Image_ID,
                                Role_ID = r.Equipment.Role_ID,
                                Equipment_Name = r.Equipment.Equipment_Name,
                                Equipment_Quantity = r.Equipment.Equipment_Quantity,
                                Equipment_Available = r.Equipment.Equipment_Available,
                                Equipment_Description = r.Equipment.Equipment_Description
                            }
                            : null
                    }).ToListAsync();

                return rentalDTOs;
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
                var rentalDTO = await _context.Rentals
                    .Include(r => r.User)
                    .Include(r => r.Equipment)
                    .Where(r => r.Rental_ID == rental_ID)
                    .Select(r => new RentalDTO
                    {
                        Rental_ID = r.Rental_ID,
                        User_ID = r.User_ID,
                        Equipment_ID = r.Equipment_ID,
                        Rental_Start_Date = r.Rental_Start_Date,
                        Rental_End_Date = r.Rental_End_Date,
                        Rental_Approved = r.Rental_Approved,
                        Rental_Returned = r.Rental_Returned,

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

                        Equipment = r.Equipment != null
                            ? new EquipmentDTO
                            {
                                Equipment_ID = r.Equipment.Equipment_ID,
                                Image_ID = r.Equipment.Image_ID,
                                Role_ID = r.Equipment.Role_ID,
                                Equipment_Name = r.Equipment.Equipment_Name,
                                Equipment_Quantity = r.Equipment.Equipment_Quantity,
                                Equipment_Available = r.Equipment.Equipment_Available,
                                Equipment_Description = r.Equipment.Equipment_Description
                            }
                            : null
                    }).SingleOrDefaultAsync();

                return rentalDTO;
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
                var rental = new Rental();

                rental.User = await _context.Users.FindAsync(rentalDTO.User_ID);
                rental.Equipment = await _context.Equipments.FindAsync(rentalDTO.Equipment_ID);
                rental.Rental_Start_Date = rentalDTO.Rental_Start_Date;
                rental.Rental_End_Date = rentalDTO.Rental_End_Date;
                rental.Rental_Approved = rentalDTO.Rental_Approved;
                rental.Rental_Returned = rentalDTO.Rental_Returned;

                await _context.Rentals.AddAsync(rental);
                await _context.SaveChangesAsync();

                rentalDTO.Rental_ID = rental.Rental_ID;
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
                var rental = await _context.Rentals
                    .Include(r => r.User)
                    .Include(r => r.Equipment)
                    .Where(r => r.Rental_ID == rentalDTO.Rental_ID)
                    .FirstOrDefaultAsync();

                if (rental == null)
                {
                    throw new Exception("Not Found");
                }

                if (rental.User.User_ID != rentalDTO.User_ID)
                {
                    rental.User = await _context.Users.FindAsync(rentalDTO.User_ID);
                }
                if (rental.Equipment.Equipment_ID != rentalDTO.Equipment_ID)
                {
                    rental.Equipment = await _context.Equipments.FindAsync(rentalDTO.Equipment_ID);
                }

                rental.Rental_Start_Date = rentalDTO.Rental_Start_Date;
                rental.Rental_End_Date = rentalDTO.Rental_End_Date;
                rental.Rental_Approved = rentalDTO.Rental_Approved;
                rental.Rental_Returned = rentalDTO.Rental_Returned;

                await _context.SaveChangesAsync();
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
                _context.Rentals.Remove(await _context.Rentals.FindAsync(rental_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}