using System.ComponentModel.DataAnnotations;

namespace SRW_Frontend_Server.Models
{
    public class Opportunity
    {
        public int Opportunity_ID { get; set; }

        public int? OpportunityType_ID { get; set; }

        public int? Image_ID { get; set; }

        public int? Location_ID { get; set; }

        public int? Role_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Opportunity_Name { get; set; }

        [MaxLength(100)]
        public string Opportunity_Host_Name { get; set; }

        [MaxLength(100)]
        public string? Opportunity_Email { get; set; }

        [MaxLength(20)]
        public string? Opportunity_Phone { get; set; }

        public DateTime? Opportunity_Start_Date { get; set; }

        public DateTime? Opportunity_End_Date { get; set; }

        [Required]
        [MaxLength(500)]
        public string Opportunity_Description { get; set; }

        public OpportunityType? OpportunityType { get; set; }
        public Image? Image { get; set; }
        public Location? Location { get; set; }
        public Role? Role { get; set; }
    }
}
