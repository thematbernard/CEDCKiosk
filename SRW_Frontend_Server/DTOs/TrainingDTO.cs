namespace SRW_Frontend_Server.DTOs
{
    public class TrainingDTO
    {
        public int Training_ID { get; set; }

        public int? Image_ID { get; set; }


        public string Training_Name { get; set; }

        public string Training_Certificate { get; set; }

        public string Training_Link { get; set; }

        public string Training_Description { get; set; }

        public ImageDTO? Image { get; set; }

    }
}
