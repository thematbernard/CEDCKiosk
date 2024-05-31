using System.ComponentModel.DataAnnotations;

namespace SRW_Backend_API.Models
{
    public class Function
    {
        public int Function_ID { get; set; }

        public int Image_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Function_Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Function_Address { get; set; }

        [Required]
        [MaxLength(500)]
        public string Function_Description { get; set; }

        public Image? Image { get; set; }
    }
}
