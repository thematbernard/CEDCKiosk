using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class DatasetTypeRepository: IDatasetTypeRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public DatasetTypeRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DatasetTypeDTO>> GetAllDatasetTypes()
        {
            try
            {
                var datasetTypeDTOs = await _context.DatasetTypes
                    .Select(dt => new DatasetTypeDTO
                    {
                        DatasetType_ID = dt.DatasetType_ID,
                        DatasetType_Name = dt.DatasetType_Name
                    }).ToListAsync();
                return datasetTypeDTOs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DatasetTypeDTO> GetDatasetTypeById(int datasetType_ID)
        {
            try
            {
                var datasetTypeDTO = await _context.DatasetTypes
                    .Where(dt => dt.DatasetType_ID == datasetType_ID)
                    .Select(dt => new DatasetTypeDTO
                    {
                        DatasetType_ID = dt.DatasetType_ID,
                        DatasetType_Name = dt.DatasetType_Name
                    }).SingleOrDefaultAsync();
                return datasetTypeDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DatasetTypeDTO> GetDatasetTypeByName(string datasetTypeName)
        {
            try
            {
                var datasetTypeDTO = await _context.DatasetTypes
                    .Where(dt => dt.DatasetType_Name == datasetTypeName)
                    .Select(dt => new DatasetTypeDTO
                    {
                        DatasetType_ID = dt.DatasetType_ID,
                        DatasetType_Name = dt.DatasetType_Name
                    }).SingleOrDefaultAsync();
                return datasetTypeDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateDatasetType(DatasetTypeDTO datasetTypeDTO)
        {
            try
            {
                var datasetType = new DatasetType();

                datasetType.DatasetType_Name = datasetTypeDTO.DatasetType_Name;
                //datasetType.DatasetType_ID = datasetTypeDTO.DatasetType_ID;

                await _context.DatasetTypes.AddAsync(datasetType);
                await _context.SaveChangesAsync();

                datasetTypeDTO.DatasetType_ID = datasetType.DatasetType_ID;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateDatasetType(DatasetTypeDTO datasetTypeDTO)
        {
            try
            {
                var datasetType = await _context.DatasetTypes
                    .Where(dt => dt.DatasetType_ID == datasetTypeDTO.DatasetType_ID)
                    .FirstOrDefaultAsync();

                if(datasetType == null)
                {
                    throw new Exception("Not found");
                }
                datasetType.DatasetType_Name = datasetTypeDTO.DatasetType_Name;
                datasetType.DatasetType_ID = datasetTypeDTO.DatasetType_ID;

                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteDatasetType(int datasetType_ID)
        {
            try
            {
                _context.DatasetTypes.Remove(await _context.DatasetTypes.FindAsync(datasetType_ID));
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
