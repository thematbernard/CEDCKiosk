using System.ComponentModel.DataAnnotations;

namespace SRW_Frontend_Server.Models
{
    public class Assistance
    {
        public int Assistance_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Assistance_First_Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Assistance_Last_Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Assistance_Email { get; set; }

        [MaxLength(100)]
        public string? Assistance_Phone { get; set; }

        [Required]
        [MaxLength(500)]
        public string Assistance_Description { get; set; }

        [Required]
        public bool Assistance_Resolved { get; set; }
    }
}
