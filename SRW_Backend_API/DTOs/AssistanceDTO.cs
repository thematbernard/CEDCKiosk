namespace SRW_Backend_API.DTOs
{
    public class AssistanceDTO
    {
        public int Assistance_ID { get; set; }

        public string Assistance_First_Name { get; set; }

        public string Assistance_Last_Name { get; set; }

        public string Assistance_Email { get; set; }

        public string? Assistance_Phone { get; set; }

        public string Assistance_Description { get; set; }

        public bool Assistance_Resolved { get; set; }
    }
}
