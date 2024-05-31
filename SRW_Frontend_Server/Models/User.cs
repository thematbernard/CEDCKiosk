using System.ComponentModel.DataAnnotations;

namespace SRW_Frontend_Server.Models
{
    public class User
    {
        public int User_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string User_First_Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string User_Last_Name { get; set; }

        [MaxLength(20)]
        public string? User_Phone { get; set; }

        [Required]
        [MaxLength(100)]
        public string User_Email { get; set; }

        [Required]
        [MaxLength(128)]
        public string User_Password { get; set; }
    }
}