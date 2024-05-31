namespace SRW_Backend_API.DTOs
{
    public class FunctionDTO
    {
        public int Function_ID { get; set; }

        public int Image_ID { get; set; }

        public string Function_Name { get; set; }

        public string Function_Address { get; set; }

        public string Function_Description { get; set; }

        public ImageDTO? Image { get; set; }
    }
}
