namespace SRW_Backend_API.DTOs
{
    public class ResourceTagDTO
    {
        public int Resource_ID { get; set; }
        public int Tag_ID { get; set; }

        public ResourceDTO? Resource { get; set; }
        public TagDTO? Tag { get; set; }
    }
}
