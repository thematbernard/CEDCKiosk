namespace SRW_Backend_API.DTOs
{
    public class RegistrationDTO
    {
        public int Registration_ID { get; set; }

        public int User_ID { get; set; }

        public int Opportunity_ID { get; set; }

        public bool Registration_Notification { get; set; }

        public UserDTO? User { get; set; }
        public OpportunityDTO? Opportunity { get; set; }
    }
}
