using System.ComponentModel.DataAnnotations;

namespace SRW_Frontend_Server.Models
{
    public class OpportunityType
    {
        public int OpportunityType_ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string OpportunityType_Name { get; set; }
    }
}
