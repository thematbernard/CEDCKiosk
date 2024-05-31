namespace SRW_Backend_API.Models
{
    public class Dataset
    {
        public int Dataset_ID { get; set; }
        public int DatasetType_ID { get; set; }
        public int Sector_ID { get; set; }
        public string Dataset_Name { get; set;}
        public string Dataset_Link { get; set;}

        public DatasetType? DatasetType { get; set; }
        public Sector? Sector { get; set; }

    }
}
