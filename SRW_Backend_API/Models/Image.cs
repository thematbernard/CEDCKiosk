using System.ComponentModel.DataAnnotations;

namespace SRW_Backend_API.Models
{
    public class Image
    {
        public int Image_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Image_Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Image_Address { get; set; }
    }
}
