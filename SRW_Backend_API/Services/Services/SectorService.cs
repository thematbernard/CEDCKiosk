using SRW_Backend_API.Repository.Interfaces;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Services.Interfaces;

namespace SRW_Backend_API.Services.Services
{
    public class SectorService: ISectorService
    {
        private readonly ISectorRepository _sectorRepository;
        public SectorService(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public async Task<IEnumerable<SectorDTO>> GetAllSectors()
        {
            try
            {
                return await _sectorRepository.GetAllSectors();
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
                return await _sectorRepository.GetSectorByName(sectorName);
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
                return await _sectorRepository.GetSectorById(sector_ID);
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
                await _sectorRepository.CreateSector(sectorDTO);
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
                await _sectorRepository.UpdateSector(sectorDTO);
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
                await _sectorRepository.DeleteSector(sector_ID);
            }
            catch
            {
                throw;
            }
        }
    }
}
