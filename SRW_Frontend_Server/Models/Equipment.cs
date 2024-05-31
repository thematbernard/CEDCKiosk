using System.ComponentModel.DataAnnotations;

namespace SRW_Frontend_Server.Models
{
    public class Equipment
    {
        public int Equipment_ID { get; set; }

        public int? Image_ID { get; set; }

        public int? Role_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Equipment_Name { get; set; }

        [Required]
        public int Equipment_Quantity { get; set; }

        [Required]
        public int Equipment_Available { get; set; }

        [Required]
        [MaxLength(500)]
        public string Equipment_Description { get; set; }

        public Image? Image { get; set; }
        public Role? Role { get; set; }
    }
}
