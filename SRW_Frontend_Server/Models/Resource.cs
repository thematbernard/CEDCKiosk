using System.ComponentModel.DataAnnotations;

namespace SRW_Frontend_Server.Models
{
    public class Resource
    {
        public int Resource_ID { get; set; }

        public int Image_ID { get; set; }

        public int? Location_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Resource_Name { get; set; }

        [MaxLength(100)]
        public string Resource_Phone { get; set; }

        [MaxLength(100)]
        public string Resource_Website { get; set; }

        [MaxLength(100)]
        public string Resource_Eligibility { get; set; }

        [Required]
        [MaxLength(500)]
        public string Resource_Description { get; set; }

        public Image? Image { get; set; }
        public Location? Location { get; set; }
    }
}