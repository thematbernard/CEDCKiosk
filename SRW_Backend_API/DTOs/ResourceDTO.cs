namespace SRW_Backend_API.DTOs
{
    public class ResourceDTO
    {
        public int Resource_ID { get; set; }
        public int Image_ID { get; set; }
        public int? Location_ID { get; set; }
        public string Resource_Name { get; set; }
        public string? Resource_Phone { get; set; }
        public string? Resource_Website { get; set; }
        public string? Resource_Eligibility { get; set; }
        public string Resource_Description { get; set; }

        public ImageDTO? Image { get; set; }
        public LocationDTO? Location { get; set; }
    }
}
