using System.ComponentModel.DataAnnotations;

namespace SRW_Backend_API.Models
{
    public class Training
    {
        public int Training_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Training_Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Training_Certificate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Training_Link {  get; set; }

        public string Training_Description { get; set; }

        public int? Image_ID { get; set; }

        public Image? Image { get; set; }

    }
}
