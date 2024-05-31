namespace SRW_Frontend_Server.DTOs
{
    public class OpportunityDTO
    {
        public int Opportunity_ID { get; set; }

        public int? OpportunityType_ID { get; set; }

        public int? Image_ID { get; set; }

        public int? Location_ID { get; set; }

        public int? Role_ID { get; set; }

        public string Opportunity_Name { get; set; }

        public string Opportunity_Host_Name { get; set; }

        public string? Opportunity_Email { get; set; }

        public string? Opportunity_Phone { get; set; }

        public DateTime? Opportunity_Start_Date { get; set; }

        public DateTime? Opportunity_End_Date { get; set; }

        public string Opportunity_Description { get; set; }

        public OpportunityTypeDTO? OpportunityType { get; set; }
        public ImageDTO? Image { get; set; }
        public LocationDTO? Location { get; set; }
        public RoleDTO? Role { get; set; }
    }
}
