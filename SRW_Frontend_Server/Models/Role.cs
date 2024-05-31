using System.ComponentModel.DataAnnotations;

namespace SRW_Frontend_Server.Models
{
    public class Role
    {
        public int Role_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Role_Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Role_Description { get; set; }
    }
}
