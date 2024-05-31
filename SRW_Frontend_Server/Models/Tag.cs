using System.ComponentModel.DataAnnotations;

namespace SRW_Frontend_Server.Models
{
    public class Tag
    {
        public int Tag_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Tag_Name { get; set; }
    }
}
