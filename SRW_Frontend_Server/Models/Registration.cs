using System.ComponentModel.DataAnnotations;

namespace SRW_Frontend_Server.Models
{
    public class Registration
    {
        public int Registration_ID { get; set; }

        public int User_ID { get; set; }

        public int Opportunity_ID { get; set; }

        [Required]
        public bool Registration_Notification { get; set; }

        public User? User { get; set; }
        public Opportunity? Opportunity { get; set; }
    }
}
