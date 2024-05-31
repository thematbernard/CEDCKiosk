namespace SRW_Backend_API.DTOs
{
    public class UserDTO
    {
        public int User_ID { get; set; }

        public string User_First_Name { get; set; }

        public string User_Last_Name { get; set; }

        public string? User_Phone { get; set; }

        public string User_Email { get; set; }

        public string User_Password { get; set; }
    }
}