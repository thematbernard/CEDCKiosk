using SRW_Backend_API.DTOs;

namespace SRW_Backend_API.Repository.Interfaces
{
    public interface ISectorRepository
    {
        Task<IEnumerable<SectorDTO>> GetAllSectors();
        Task<SectorDTO> GetSectorByName(string sectorName);
        Task<SectorDTO> GetSectorById(int sector_ID);
        Task CreateSector(SectorDTO sector);
        Task UpdateSector(SectorDTO sector);
        Task DeleteSector(int sector_ID);
    }
}
