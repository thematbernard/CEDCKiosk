using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class AssistanceRepository : IAssistanceRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public AssistanceRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AssistanceDTO>> GetAllAssistances()
        {
            try
            {
                var assistanceDTOs = await _context.Assistances
                .Select(a => new AssistanceDTO
                {
                    Assistance_First_Name = a.Assistance_First_Name,
                    Assistance_Last_Name = a.Assistance_Last_Name,
                    Assistance_Email = a.Assistance_Email,
                    Assistance_Phone = a.Assistance_Phone,
                    Assistance_Description = a.Assistance_Description,
                    Assistance_Resolved = a.Assistance_Resolved
                }).ToListAsync();

                return assistanceDTOs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<AssistanceDTO> GetAssistanceById(int assistance_ID)
        {
            try
            {
                var assistanceDTO = await _context.Assistances
                .Where(a => a.Assistance_ID == assistance_ID)
                .Select(a => new AssistanceDTO
                {
                    Assistance_First_Name = a.Assistance_First_Name,
                    Assistance_Last_Name = a.Assistance_Last_Name,
                    Assistance_Email = a.Assistance_Email,
                    Assistance_Phone = a.Assistance_Phone,
                    Assistance_Description = a.Assistance_Description,
                    Assistance_Resolved = a.Assistance_Resolved
                }).SingleOrDefaultAsync();

                return assistanceDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateAssistance(AssistanceDTO assistanceDTO)
        {
            try
            {
                var assistance = new Assistance();

                assistance.Assistance_First_Name = assistanceDTO.Assistance_First_Name;
                assistance.Assistance_Last_Name = assistanceDTO.Assistance_Last_Name;
                assistance.Assistance_Email = assistanceDTO.Assistance_Email;
                assistance.Assistance_Phone = assistanceDTO.Assistance_Phone;
                assistance.Assistance_Description = assistanceDTO.Assistance_Description;
                assistance.Assistance_Resolved = assistanceDTO.Assistance_Resolved;

                await _context.Assistances.AddAsync(assistance);
                await _context.SaveChangesAsync();

                assistanceDTO.Assistance_ID = assistance.Assistance_ID;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateAssistance(AssistanceDTO assistanceDTO)
        {
            try
            {
                Assistance assistance = await _context.Assistances
                .Where(a => a.Assistance_ID == assistanceDTO.Assistance_ID).FirstOrDefaultAsync();

                if (assistance == null)
                {
                    throw new Exception("Not Found");
                }

                assistance.Assistance_First_Name = string.IsNullOrWhiteSpace(assistanceDTO.Assistance_First_Name) ? null : assistanceDTO.Assistance_First_Name;
                assistance.Assistance_Last_Name = string.IsNullOrWhiteSpace(assistanceDTO.Assistance_Last_Name) ? null : assistanceDTO.Assistance_Last_Name;
                assistance.Assistance_Email = string.IsNullOrWhiteSpace(assistanceDTO.Assistance_Email) ? null : assistanceDTO.Assistance_Email;
                assistance.Assistance_Phone = string.IsNullOrWhiteSpace(assistanceDTO.Assistance_Phone) ? null : assistanceDTO.Assistance_Phone;
                assistance.Assistance_Description = string.IsNullOrWhiteSpace(assistanceDTO.Assistance_Description) ? null : assistanceDTO.Assistance_Description;
                assistance.Assistance_Resolved = assistanceDTO.Assistance_Resolved;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteAssistance(int assistance_ID)
        {
            try
            {
                _context.Assistances.Remove(await _context.Assistances.FindAsync(assistance_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}