using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class SectorRepository: ISectorRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public SectorRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SectorDTO>> GetAllSectors()
        {
            try
            {
                var sectorDTOs = await _context.Sectors
                .Select(s => new SectorDTO
                {
                    Sector_ID = s.Sector_ID,
                    Sector_Name = s.Sector_Name
                }).ToListAsync();

                return sectorDTOs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<SectorDTO> GetSectorByName(string sectorName)
        {
            try
            {
                var sectorDTO = await _context.Sectors
                    .Where(s => s.Sector_Name == sectorName)
                    .Select(s => new SectorDTO {
                        Sector_ID = s.Sector_ID,
                        Sector_Name = s.Sector_Name
                    }).SingleOrDefaultAsync();
                return sectorDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task<SectorDTO> GetSectorById(int sector_ID)
        {
            try
            {
                var sectorDTO = await _context.Sectors
                    .Where(s => s.Sector_ID == sector_ID)
                    .Select(s => new SectorDTO
                    {
                        Sector_ID = s.Sector_ID,
                        Sector_Name = s.Sector_Name
                    }).SingleOrDefaultAsync();
                return sectorDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateSector(SectorDTO sectorDTO)
        {
            try
            {
                var sector = new Sector();

                sector.Sector_Name = sectorDTO.Sector_Name;

                await _context.Sectors.AddAsync(sector);
                await _context.SaveChangesAsync();

                sectorDTO.Sector_ID = sector.Sector_ID;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateSector(SectorDTO sectorDTO)
        {
            try
            {
                var sector = await _context.Sectors
                    .Where(s => s.Sector_ID == sectorDTO.Sector_ID)
                    .FirstOrDefaultAsync();

                if(sector == null)
                {
                    throw new Exception("Not Found");
                }

                sector.Sector_Name = sectorDTO.Sector_Name;
                sector.Sector_ID = sectorDTO.Sector_ID;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteSector(int sector_ID)
        {
            try
            {
                _context.Sectors.Remove(await _context.Sectors.FindAsync(sector_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
