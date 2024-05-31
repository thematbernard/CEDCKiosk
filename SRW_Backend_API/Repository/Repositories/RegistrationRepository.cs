using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public RegistrationRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RegistrationDTO>> GetAllRegistrations()
        {
            try
            {
                var registrationDTOs = await _context.Registrations
                    .Include(r => r.User)
                    .Include(r => r.Opportunity)
                    .Select(r => new RegistrationDTO
                    {
                        Registration_ID = r.Registration_ID,
                        User_ID = r.User_ID,
                        Opportunity_ID = r.Opportunity_ID,
                        Registration_Notification = r.Registration_Notification,

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

                        Opportunity = r.Opportunity != null
                            ? new OpportunityDTO
                            {
                                Opportunity_ID = r.Opportunity.Opportunity_ID,
                                OpportunityType_ID = r.Opportunity.OpportunityType_ID,
                                Image_ID = r.Opportunity.Image_ID,
                                Location_ID = r.Opportunity.Location_ID,
                                Role_ID = r.Opportunity.Role_ID,
                                Opportunity_Name = r.Opportunity.Opportunity_Name,
                                Opportunity_Email = r.Opportunity.Opportunity_Email,
                                Opportunity_Phone = r.Opportunity.Opportunity_Phone,
                                Opportunity_Start_Date = r.Opportunity.Opportunity_Start_Date,
                                Opportunity_End_Date = r.Opportunity.Opportunity_End_Date,
                                Opportunity_Description = r.Opportunity.Opportunity_Description
                            }
                            : null
                    })
                    .ToListAsync();

                return registrationDTOs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<RegistrationDTO> GetRegistrationById(int registration_ID)
        {
            try
            {
                var registrationDTO = await _context.Registrations
                    .Include(r => r.User)
                    .Include(r => r.Opportunity)
                    .Where(r => r.Registration_ID == registration_ID)
                    .Select(r => new RegistrationDTO
                    {
                        Registration_ID = r.Registration_ID,
                        User_ID = r.User_ID,
                        Opportunity_ID = r.Opportunity_ID,
                        Registration_Notification = r.Registration_Notification,

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

                        Opportunity = r.Opportunity != null
                            ? new OpportunityDTO
                            {
                                Opportunity_ID = r.Opportunity.Opportunity_ID,
                                OpportunityType_ID = r.Opportunity.OpportunityType_ID,
                                Image_ID = r.Opportunity.Image_ID,
                                Location_ID = r.Opportunity.Location_ID,
                                Role_ID = r.Opportunity.Role_ID,
                                Opportunity_Name = r.Opportunity.Opportunity_Name,
                                Opportunity_Email = r.Opportunity.Opportunity_Email,
                                Opportunity_Phone = r.Opportunity.Opportunity_Phone,
                                Opportunity_Start_Date = r.Opportunity.Opportunity_Start_Date,
                                Opportunity_End_Date = r.Opportunity.Opportunity_End_Date,
                                Opportunity_Description = r.Opportunity.Opportunity_Description
                            }
                            : null
                    })
                    .SingleOrDefaultAsync();

                return registrationDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateRegistration(RegistrationDTO registrationDTO)
        {
            try
            {
                var registration = new Registration();

                registration.User = await _context.Users.FindAsync(registrationDTO.User_ID);
                registration.Opportunity = await _context.Opportunitys.FindAsync(registrationDTO.Opportunity_ID);
                registration.Registration_Notification = registrationDTO.Registration_Notification;

                await _context.Registrations.AddAsync(registration);
                await _context.SaveChangesAsync();

                registrationDTO.Registration_ID = registration.Registration_ID;
                registrationDTO.User = new UserDTO()
                {
                    User_ID = registration.User.User_ID,
                    User_First_Name = registration.User.User_First_Name,
                    User_Last_Name = registration.User.User_Last_Name,
                    User_Email = registration.User.User_Email,
                    User_Password = registration.User.User_Password,
                    User_Phone = registration.User.User_Phone
                };
                registrationDTO.Opportunity = new OpportunityDTO()
                {
                    Opportunity_ID = registration.Opportunity.Opportunity_ID,
                    Opportunity_Name = registration.Opportunity.Opportunity_Name,
                    Opportunity_Email = registration.Opportunity.Opportunity_Email,
                    Opportunity_Host_Name = registration.Opportunity.Opportunity_Host_Name,
                    Opportunity_Phone = registration.Opportunity.Opportunity_Phone,
                    Opportunity_Start_Date = registration.Opportunity.Opportunity_Start_Date,
                    Opportunity_End_Date = registration.Opportunity.Opportunity_End_Date,
                    Opportunity_Description = registration.Opportunity.Opportunity_Description,
                    OpportunityType_ID = registration.Opportunity.OpportunityType_ID,
                    OpportunityType = new OpportunityTypeDTO()
                    {
                        OpportunityType_ID = registration.Opportunity.OpportunityType.OpportunityType_ID,
                        OpportunityType_Name = registration.Opportunity.OpportunityType.OpportunityType_Name,
                    }
                };
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateRegistration(RegistrationDTO registrationDTO)
        {
            try
            {
                var registration = await _context.Registrations
                    .Include(r => r.User)
                    .Include(r => r.Opportunity)
                    .Where(r => r.Registration_ID == registrationDTO.Registration_ID)
                    .FirstOrDefaultAsync();

                if (registration == null)
                {
                    throw new Exception("Not Found");
                }

                if (registration.User.User_ID != registrationDTO.User_ID)
                {
                    registration.User = await _context.Users.FindAsync(registrationDTO.User_ID);
                }
                if (registration.Opportunity.Opportunity_ID != registrationDTO.Opportunity_ID)
                {
                    registration.Opportunity = await _context.Opportunitys.FindAsync(registrationDTO.Opportunity_ID);
                }

                registration.Registration_Notification = registrationDTO.Registration_Notification;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteRegistration(int registration_ID)
        {
            try
            {
                _context.Registrations.Remove(await _context.Registrations.FindAsync(registration_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
