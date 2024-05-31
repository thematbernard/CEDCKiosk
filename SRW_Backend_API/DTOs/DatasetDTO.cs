using SRW_Backend_API.Models;

namespace SRW_Backend_API.DTOs
{
    public class DatasetDTO
    {
        public int Dataset_ID { get; set; }
        public int DatasetType_ID { get; set; }
        public int Sector_ID { get; set; }
        public string Dataset_Name { get; set; }
        public string Dataset_Link { get; set; }

        public DatasetTypeDTO? DatasetType { get; set; }
        public SectorDTO? Sector { get; set; }
    }
}
