using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SRW_Backend_API.Repository.Repositories
{
    public class OpportunityRepository : IOpportunityRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public OpportunityRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OpportunityDTO>> GetAllOpportunities()
        {
            try
            {
                var opportunityDTOs = await _context.Opportunitys
                    .Include(o => o.OpportunityType)
                    .Include(o => o.Image)
                    .Include(o => o.Location)
                    .Include(o => o.Role)
                    .Select(o => new OpportunityDTO
                    {
                        Opportunity_ID = o.Opportunity_ID,
                        OpportunityType_ID = o.OpportunityType_ID,
                        Image_ID = o.Image_ID,
                        Location_ID = o.Location_ID,
                        Role_ID = o.Role_ID,
                        Opportunity_Name = o.Opportunity_Name,
                        Opportunity_Host_Name = o.Opportunity_Host_Name,
                        Opportunity_Email = o.Opportunity_Email,
                        Opportunity_Phone = o.Opportunity_Phone,
                        Opportunity_Start_Date = o.Opportunity_Start_Date,
                        Opportunity_End_Date = o.Opportunity_End_Date,
                        Opportunity_Description = o.Opportunity_Description,

                        OpportunityType = new OpportunityTypeDTO
                        {
                            OpportunityType_ID = o.OpportunityType.OpportunityType_ID,
                            OpportunityType_Name = o.OpportunityType.OpportunityType_Name
                        },

                        Image = new ImageDTO
                        {
                            Image_ID = o.Image.Image_ID,
                            Image_Name = o.Image.Image_Name,
                            Image_Address = o.Image.Image_Address
                        },

                        Location = new LocationDTO
                        {
                            Location_ID = o.Location.Location_ID,
                            Location_Name = o.Location.Location_Name,
                            Location_Street = o.Location.Location_Street,
                            Location_City = o.Location.Location_City,
                            Location_County = o.Location.Location_County,
                            Location_State = o.Location.Location_State,
                            Location_Country = o.Location.Location_Country,
                            Location_Zip = o.Location.Location_Zip
                        },

                        Role = new RoleDTO
                        {
                            Role_ID = o.Role.Role_ID,
                            Role_Name = o.Role.Role_Name,
                            Role_Description = o.Role.Role_Description
                        }
                    })
                    .ToListAsync();

                return opportunityDTOs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<OpportunityDTO> GetOpportunityById(int opportunity_ID)
        {
            try
            {
                var opportunityDTO = await _context.Opportunitys
                    .Include(o => o.OpportunityType)
                    .Include(o => o.Image)
                    .Include(o => o.Location)
                    .Include(o => o.Role)
                    .Where(o => o.Opportunity_ID == opportunity_ID)
                    .Select(o => new OpportunityDTO
                    {
                        Opportunity_ID = o.Opportunity_ID,
                        OpportunityType_ID = o.OpportunityType_ID,
                        Image_ID = o.Image_ID,
                        Location_ID = o.Location_ID,
                        Role_ID = o.Role_ID,
                        Opportunity_Name = o.Opportunity_Name,
                        Opportunity_Host_Name = o.Opportunity_Host_Name,
                        Opportunity_Email = o.Opportunity_Email,
                        Opportunity_Phone = o.Opportunity_Phone,
                        Opportunity_Start_Date = o.Opportunity_Start_Date,
                        Opportunity_End_Date = o.Opportunity_End_Date,
                        Opportunity_Description = o.Opportunity_Description,

                        OpportunityType = new OpportunityTypeDTO
                        {
                            OpportunityType_ID = o.OpportunityType.OpportunityType_ID,
                            OpportunityType_Name = o.OpportunityType.OpportunityType_Name
                        },

                        Image = new ImageDTO
                        {
                            Image_ID = o.Image.Image_ID,
                            Image_Name = o.Image.Image_Name,
                            Image_Address = o.Image.Image_Address
                        },

                        Location = new LocationDTO
                        {
                            Location_ID = o.Location.Location_ID,
                            Location_Name = o.Location.Location_Name,
                            Location_Street = o.Location.Location_Street,
                            Location_City = o.Location.Location_City,
                            Location_County = o.Location.Location_County,
                            Location_State = o.Location.Location_State,
                            Location_Country = o.Location.Location_Country,
                            Location_Zip = o.Location.Location_Zip
                        },

                        Role = new RoleDTO
                        {
                            Role_ID = o.Role.Role_ID,
                            Role_Name = o.Role.Role_Name,
                            Role_Description = o.Role.Role_Description
                        }
                    })
                    .SingleOrDefaultAsync();

                return opportunityDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateOpportunity(OpportunityDTO opportunityDTO)
        {
            try
            {
                var opportunity = new Opportunity
                {
                    OpportunityType_ID = opportunityDTO.OpportunityType_ID,
                    Image_ID = opportunityDTO.Image_ID,
                    Location_ID = opportunityDTO.Location_ID,
                    Role_ID = opportunityDTO.Role_ID,
                    Opportunity_Name = opportunityDTO.Opportunity_Name,
                    Opportunity_Host_Name = opportunityDTO.Opportunity_Host_Name,
                    Opportunity_Email = opportunityDTO.Opportunity_Email,
                    Opportunity_Phone = opportunityDTO.Opportunity_Phone,
                    Opportunity_Start_Date = opportunityDTO.Opportunity_Start_Date,
                    Opportunity_End_Date = opportunityDTO.Opportunity_End_Date,
                    Opportunity_Description = opportunityDTO.Opportunity_Description
                };

                await _context.Opportunitys.AddAsync(opportunity);
                await _context.SaveChangesAsync();
                opportunityDTO.Opportunity_ID = opportunity.Opportunity_ID;
                opportunityDTO.Image = new ImageDTO
                {
                    Image_ID = opportunity.Image.Image_ID,
                    Image_Address = opportunity.Image.Image_Address,
                    Image_Name = opportunity.Image.Image_Name
                };
                opportunityDTO.Location = new LocationDTO
                {
                    Location_ID = opportunity.Location.Location_ID,
                    Location_City = opportunity.Location.Location_City,
                    Location_Country = opportunity.Location.Location_Country,
                    Location_County = opportunity.Location.Location_County,
                    Location_Name = opportunity.Location.Location_Name,
                    Location_State = opportunity.Location.Location_State,
                    Location_Street = opportunity.Location.Location_Street,
                    Location_Zip = opportunity.Location.Location_Zip
                };

                opportunityDTO.OpportunityType = new OpportunityTypeDTO
                {
                    OpportunityType_ID = opportunity.OpportunityType.OpportunityType_ID,
                    OpportunityType_Name = opportunity.OpportunityType.OpportunityType_Name
                };

                opportunityDTO.Role = new RoleDTO
                {
                    Role_ID = opportunity.Role.Role_ID,
                    Role_Description = opportunity.Role.Role_Description,
                    Role_Name = opportunity.Role.Role_Name
                };
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateOpportunity(OpportunityDTO opportunityDTO)
        {
            try
            {
                var opportunity = await _context.Opportunitys
                    .Where(o => o.Opportunity_ID == opportunityDTO.Opportunity_ID)
                    .FirstOrDefaultAsync();

                if (opportunity == null)
                {
                    throw new Exception("Not Found");
                }

                opportunity.OpportunityType_ID = opportunityDTO.OpportunityType_ID;
                opportunity.Image_ID = opportunityDTO.Image_ID;
                opportunity.Location_ID = opportunityDTO.Location_ID;
                opportunity.Role_ID = opportunityDTO.Role_ID;
                opportunity.Opportunity_Name = opportunityDTO.Opportunity_Name;
                opportunity.Opportunity_Email = opportunityDTO.Opportunity_Email;
                opportunity.Opportunity_Phone = opportunityDTO.Opportunity_Phone;
                opportunity.Opportunity_Start_Date = opportunityDTO.Opportunity_Start_Date;
                opportunity.Opportunity_End_Date = opportunityDTO.Opportunity_End_Date;
                opportunity.Opportunity_Description = opportunityDTO.Opportunity_Description;
                
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteOpportunity(int opportunity_ID)
        {
            try
            {
                _context.Opportunitys.Remove(await _context.Opportunitys.FindAsync(opportunity_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}