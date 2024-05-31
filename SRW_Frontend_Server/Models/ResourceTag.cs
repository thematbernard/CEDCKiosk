namespace SRW_Frontend_Server.Models
{
    public class ResourceTag
    {
        public int Resource_ID { get; set; }
        public int Tag_ID { get; set; }

        public Resource? Resource { get; set; }
        public Tag? Tag { get; set; }
    }
}
