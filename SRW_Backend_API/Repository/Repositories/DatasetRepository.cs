using Microsoft.EntityFrameworkCore;
using SRW_Backend_API.Data;
using SRW_Backend_API.DTOs;
using SRW_Backend_API.Models;
using SRW_Backend_API.Repository.Interfaces;

namespace SRW_Backend_API.Repository.Repositories
{
    public class DatasetRepository: IDatasetRepository
    {
        private readonly SRWVirtualHubDbContext _context;

        public DatasetRepository(SRWVirtualHubDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DatasetDTO>> GetAllDatasets()
        {
            try
            {
                var datasetDTOs = await _context.Datasets
                    .Include(ds => ds.DatasetType)
                    .Include(ds => ds.Sector)
                    .Select(ds => new DatasetDTO
                    {
                        Dataset_ID = ds.Dataset_ID,
                        Dataset_Name = ds.Dataset_Name,
                        Dataset_Link = ds.Dataset_Link,
                        DatasetType_ID = ds.DatasetType_ID,
                        Sector_ID = ds.Sector_ID,

                        DatasetType = ds.DatasetType != null ? new DatasetTypeDTO
                        {
                            DatasetType_ID = ds.DatasetType.DatasetType_ID,
                            DatasetType_Name = ds.DatasetType.DatasetType_Name
                        } :null,

                        Sector = ds.Sector != null ? new SectorDTO
                        {
                            Sector_ID = ds.Sector.Sector_ID,
                            Sector_Name = ds.Sector.Sector_Name
                        } :null
                    }).ToListAsync();
                return datasetDTOs;
            }
            catch
            {
                throw;
            }
        }

        public async Task<DatasetDTO> GetDatasetById(int dataset_ID)
        {
            try {
                var datasetDTO = await _context.Datasets
                    .Include(ds => ds.DatasetType)
                    .Include(ds => ds.Sector)
                    .Where(ds => ds.Dataset_ID == dataset_ID)
                    .Select(ds => new DatasetDTO
                    {
                        Dataset_ID = ds.Dataset_ID,
                        Dataset_Name = ds.Dataset_Name,
                        Dataset_Link = ds.Dataset_Link,
                        DatasetType_ID = ds.DatasetType_ID,
                        Sector_ID = ds.Sector_ID,

                        DatasetType = ds.DatasetType != null ? new DatasetTypeDTO
                        {
                            DatasetType_ID = ds.DatasetType.DatasetType_ID,
                            DatasetType_Name = ds.DatasetType.DatasetType_Name
                        } :null,

                        Sector = ds.Sector != null ? new SectorDTO
                        {
                            Sector_ID = ds.Sector.Sector_ID,
                            Sector_Name = ds.Sector.Sector_Name
                        } :null
                    }).SingleOrDefaultAsync();
                return datasetDTO;
            }
            catch
            {
                throw;
            }
        }

        public async Task CreateDataset(DatasetDTO datasetDTO)
        {
            try
            {
                var dataset = new Dataset
                {
                    Dataset_Name = datasetDTO.Dataset_Name,
                    Dataset_Link = datasetDTO.Dataset_Link,
                    DatasetType_ID = datasetDTO.DatasetType_ID,
                    Sector_ID = datasetDTO.Sector_ID
                };

                await _context.Datasets.AddAsync(dataset);
                await _context.SaveChangesAsync();

                datasetDTO.Dataset_ID = dataset.Dataset_ID;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateDataset(DatasetDTO datasetDTO)
        {
            try
            {
                var dataset = await _context.Datasets
                    .Include(ds => ds.Sector)
                    .Include(ds => ds.DatasetType)
                    .Where(ds => ds.Dataset_ID == datasetDTO.Dataset_ID)
                    .FirstOrDefaultAsync();
                
                if(dataset == null)
                {
                    throw new Exception("Not Found");
                }

                if(dataset.Sector.Sector_ID != datasetDTO.Sector_ID)
                {
                    dataset.Sector = await _context.Sectors.FindAsync(datasetDTO.Sector_ID);
                }

                if(dataset.DatasetType.DatasetType_ID != datasetDTO.DatasetType_ID)
                {
                    dataset.DatasetType = await _context.DatasetTypes.FindAsync(datasetDTO.DatasetType_ID);
                }

                dataset.Dataset_Name = datasetDTO.Dataset_Name;
                dataset.Dataset_Link = datasetDTO.Dataset_Link;

                await _context.SaveChangesAsync();
            }
            catch 
            { 
                throw;
            }
        }

        public async Task DeleteDataset(int dataset_ID)
        {
            try
            {
                _context.Datasets.Remove(await _context.Datasets.FindAsync(dataset_ID));
                await _context.SaveChangesAsync();
            }
            catch 
            { 
                throw; 
            }
        }
    }
}
